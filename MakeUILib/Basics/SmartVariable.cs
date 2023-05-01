using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MakeUILib.Basics
{
    public class  SmartVariable<T>
    {
        public object ValueData;
        public Func<object, T> GetValue;

    }
}
