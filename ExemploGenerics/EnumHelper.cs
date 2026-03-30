using System;
using System.Collections.Generic;
using System.Text;

namespace ExemploGenerics
{
    public class EnumHelper<T> where T : Enum
    {
        public void PrintAll()
        {
            var values = Enum.GetValues(typeof(T));
            foreach (var x in values)
            {
                Console.WriteLine(x);
            }
        }
    }

    public class EnumHelper
    {
        public static void StaticPrintAll<T>()
        {
            var values = Enum.GetValues(typeof(T));
            foreach (var x in values)
            {
                Console.WriteLine(x);
            }
        }
    }
}
