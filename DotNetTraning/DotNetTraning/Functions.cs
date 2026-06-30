using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetTraning
{
    public static class Functions
    {
        public static void Getinputs()
        {
            Console.WriteLine("Enter the value of A: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the value of B: ");
            int b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the your choise: ");
            string Choise = Console.ReadLine();
            if (Choise == "add")
            {
                int ans = Add(a, b);
                Console.WriteLine("Addition of A & B is: " + ans);
            }
            else if (Choise == "sub")
            {
                int ans = Sub(a, b);
                Console.WriteLine("Subtraction of A & B is: " + ans);
            }
            else if (Choise == "mul")
            {
                int ans = Mul(a, b);
                Console.WriteLine("Multiplication of A & B is: " + ans);
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
        }
        public static int Add(int a, int b)
        {
            return a + b;
        }
        public static int Sub(int a, int b)
        {
            return a - b;
        }
        public static int Mul(int a, int b)
        {
            return a * b;
        }
    }
}
