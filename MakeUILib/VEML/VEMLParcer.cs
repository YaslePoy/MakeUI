﻿using MakeUILib.UI;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MakeUILib.VEML
{
    public static class VEMLParcer
    {

        static bool parsing = false;
        public static bool Parsing => parsing;
        public static Dictionary<string, object> Session = new Dictionary<string, object>();
        public static Dictionary<VEMLProperty, object> Identificated = new Dictionary<VEMLProperty, object>();
        public static Dictionary<VEMLProperty, object> Events = new Dictionary<VEMLProperty, object>();

        public static void StartSession()
        {
            Session.Clear();
            Identificated.Clear();
            Events.Clear();
        }

        public static object ParceVEML(VEMLObject obj)
        {
            var totalAssm = Utils.TotalTypes;
            Type curType = null;
            foreach (var t in totalAssm)
            {
                var attrsNP = t.GetCustomAttributes(typeof(VEMLPseudonymAttribute));
                if (attrsNP == null) continue;
                var attrs = attrsNP.Select(i => i as VEMLPseudonymAttribute).ToList();
                var need = attrs.FirstOrDefault(i => i.VEMLName == obj.TypeName);
                if (need == null && t.Name != obj.TypeName)
                    continue;
                else
                {
                    curType = t;
                    break;
                }
            }
            if (curType == null)
                return null;

            var retObj = Activator.CreateInstance(curType);
            FillFromVEML(retObj, obj);
            if (obj is VEMLCollection)
            {
                var into = new List<ViewElement>();

                foreach (var item in (obj as VEMLCollection).Items)
                {
                    into.Add((ViewElement)ParceVEML(item));
                }
                curType.GetProperty("Children").SetValue(retObj, into);
            }
            var endMethod = curType.GetMethod("EndInit");
            if (endMethod != null)
                endMethod.Invoke(retObj, null);
            return retObj;
        }
        public static void FillFromVEML(object instance, VEMLObject vemlObj)
        {
            var curType = instance.GetType();
            var retObj = instance;
            bool hasId = false;
            foreach (var prop in vemlObj.Properties)
            {

                if (prop.Name == "Id")
                    Identificated.TryAdd(prop, retObj);
                var propO = curType.GetProperty(prop.Name);
                if (propO != null)
                {
                    if (propO.PropertyType.IsEnum)
                    {
                        propO.SetValue(retObj, Enum.Parse(propO.PropertyType, prop.Value.ToString()));
                    }
                    else
                    {
                        var localVal = VEMLToRealParce(prop.Value);
                        var valueType = localVal.GetType();
                        if (valueType.IsSubclassOf(propO.PropertyType) || propO.PropertyType == valueType)
                            propO.SetValue(retObj, localVal);
                        else
                        {
                            var methods = typeof(Parsers).GetMethods();
                            var m = methods.FirstOrDefault(i => (i.GetCustomAttribute(typeof(ParceMethod)) as ParceMethod).IsFor(valueType, propO.PropertyType));
                            if (m == null)
                                return;
                            var finalValue = m.Invoke(null, new object[] { prop.Value });
                            propO.SetValue(retObj, VEMLToRealParce(finalValue));
                        }
                    }
                }
                else
                {
                    var eventField = curType.GetEvent(prop.Name);
                    if (eventField == null) continue;
                    Events.TryAdd(prop, retObj);
                }
            }
        }
        public static object VEMLToRealParce(object o)
        {
            if (o is VEMLObject)
                return ParceVEML((VEMLObject)o);
            if (o is object[])
            {
                var oArray = (object[])o;
                var retArray = new object[oArray.Length];
                for (int i = 0; i < retArray.Length; i++)
                {
                    retArray[i] = VEMLToRealParce(oArray[i]);
                }
                return retArray;
            }
            return o;
        }
        public static void LoadUpperLevel(object instance, VEMLObject obj)
        {
            parsing = true;
            FillFromVEML(instance, obj);
            var fields = instance.GetType().GetFields();
            foreach (var ided in VEMLParcer.Identificated)
            {
                var setField = fields.FirstOrDefault(i => i.Name == ided.Key.Value as string);
                if (setField == null) continue;
                setField.SetValue(instance, ided.Value);
            }

            var searchType = instance.GetType();
            var totalFields = new List<FieldInfo>();
            totalFields.AddRange(searchType.GetFields());
            foreach (var propery in VEMLParcer.Events)
            {
                var action = instance.GetType().GetMethod(propery.Key.Value.ToString());
                if (action == null) continue;
                var oType = propery.Value.GetType();
                var targetEvent = oType.GetEvent(propery.Key.Name);
                var handlerType = targetEvent.EventHandlerType;
                var del = Delegate.CreateDelegate(handlerType, instance, propery.Key.Value as string, true);
                targetEvent.AddEventHandler(propery.Value, del);
            }
            parsing = false;
        }
        public static void LoadLayout(object instance)
        {
            LoadLayout(instance, instance.GetType().Name);
        }
        public static void LoadLayout(object instance, string vemlName)
        {
            if (Utils.TotalTypes == null)
                Utils.UpdateTypes();

                var win = File.ReadAllText("Rescouces\\" + vemlName + ".veml");
                Claster c = new Claster(win);
                c.SearchStructures();
                var start = c.MainStruct();
                start.UpdateStructures();
                start.LoadText();
                start.Extend();
                var vemlFile = start.ToVEML();
                VEMLParcer.LoadUpperLevel(instance, vemlFile);            
        }
    }
}
