using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetTraning
{
    public class Generics
    {
        public static void addGenerics<T>(T a, T b)
        {
            dynamic x = a;
            dynamic y = b;
            Console.WriteLine("Sum: " + (x + y));
        }
        public static T getMax<T>(T x, T y)
        {
            dynamic a = x, b = y;
            if (a>b)
                return a;
            else
                return b;
        }
    }
}
