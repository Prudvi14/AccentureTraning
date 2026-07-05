using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetTraning
{
    delegate int MathDelegate(int a, int b);
    class MathOperations
    {
        public static int Add(int a, int b)
        {
            return a + b;
        }
        public static int Subtract(int a, int b)
        {
            return a - b;
        }
        public static int Multiply(int a, int b)
        {
            return a * b;
        }
    }
}
