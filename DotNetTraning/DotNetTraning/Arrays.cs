using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DotNetTraning
{
    public class Arrays
    {
        public static void PracticeArrays()
        {
            int[] num;
            num = new int[] { 22, 45, 67, 90, 53 };
            string[] cars = { "Volvo", "BMW", "Ford", "Mazda" };

            int n = num.Length;
            int m = cars.Length;

            for (int i=0; i<m; i++)
            {
                Console.WriteLine(num[i]);
            }

            Console.WriteLine("");
            Console.WriteLine("Largest number is: " + num.Max());
            Console.WriteLine("Smallest number is: " + num.Min());
            Console.WriteLine("Sum of all numbers is: " + num.Sum());

            Console.WriteLine("");
            Array.Sort(cars);
            foreach (string i in cars)
            {
                Console.WriteLine(i);
            }


            Console.WriteLine("");
            Console.WriteLine("Two dimentional array:");
            int[,] numbers = { { 1, 4, 2 }, { 3, 6, 8 } };
            Console.WriteLine(numbers[0, 2]);

            int n1 = numbers.GetLength(0);
            int n2 = numbers.GetLength(1);
            for(int i=0; i<n1; i++)
            {
                for(int j=0; j<n2; j++)
                {
                    Console.WriteLine(numbers[i,j]);
                }
            }
        }
    }
}
