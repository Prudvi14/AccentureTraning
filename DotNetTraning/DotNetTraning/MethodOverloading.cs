using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetTraning
{
    public class Calculator
    {
        public int Add(int a, int b){
            Console.WriteLine("int + int");
            return a + b;
        }
        public double Add(double a, double b){
            Console.WriteLine("double + double");
            return a + b;
        }
        public int Add(int a, int b, int c){
            Console.WriteLine("int + int + int");
            return a + b + c;
        }
        public string Add(string a, string b)
        {
            Console.WriteLine("string + string");
            return a + b;
        }
    }
}
