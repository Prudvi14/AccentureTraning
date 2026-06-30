using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetTraning
{
    public class Nullabel
    {
        public static void ShowNullables()
        {
            int a = 10;
            int? b = null;
            int finalvalue = b ?? 0;
            Console.WriteLine("Printing int a value: " + a);
            Console.WriteLine("Printing int b value if null print finalvalue: " + finalvalue);


            Console.WriteLine("\n");
            Console.WriteLine("Boxing and UnBoxing");
            int num = 100;
            object obj = num;
            Console.WriteLine("Boxing: value type to reference type: " + obj);
            int value = (int)obj;
            Console.WriteLine("UnBoxing: reference type to value type: " + value);
        }
    }
}
