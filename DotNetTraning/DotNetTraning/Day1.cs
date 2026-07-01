using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DotNetTraning
{
    public class Day1
    {
        public static void PracticeDay()
        {
            //1: Variables and Data Types
            //Q1.Find the sum of two numbers.
            int m1 = 10;
            int m2= 20;
            Console.WriteLine(m1 + m2);
            Console.WriteLine("");

            //Q2.Swap two numbers without using a third variable.
            int n1 = 90;
            int n2 = 45;
            Console.WriteLine("N1: " + n1);
            Console.WriteLine("N2: " + n2);
            n1 = n1 ^ n2;
            n2= n1 ^ n2;
            n1= n1 ^ n2;
            Console.WriteLine("N1: "+n1);
            Console.WriteLine("N2: " + n2);
            Console.WriteLine("");

            //Q3.Check whether a number is even or odd.
            Console.WriteLine("Enter a number: ");
            int num=Convert.ToInt32(Console.ReadLine());
            if (num % 2 == 0) Console.WriteLine(num+" is Even");
            else Console.WriteLine("num is Odd");
            Console.WriteLine("");

            //2: Conditional Statements
            //Q1.Find the largest among three numbers.
            int[] num1 = { 22, 45, 67, 90, 53 };
            Console.WriteLine("Largest number is: " + num1.Max());
            Console.WriteLine("");

            //Q2.Grade calculator based on marks.
            Console.WriteLine("Enter Marks: ");
            int marks = Convert.ToInt32(Console.ReadLine());
            if (marks >= 90) Console.WriteLine("Grade is: O");
            else if (marks >= 80 && marks < 90) Console.WriteLine("Grade is: A+");
            else if (marks >= 70 && marks < 80) Console.WriteLine("Grade is: A");
            else if (marks >= 60 && marks < 70) Console.WriteLine("Grade is: B+");
            else if (marks >= 50 && marks < 60) Console.WriteLine("Grade is: B");
            else if (marks >= 40 && marks < 50) Console.WriteLine("Grade is: C");
            else if (marks > 0 && marks < 40) Console.WriteLine("Failed");
            else Console.WriteLine("Enter correct Marks");
            Console.WriteLine("");

            //3: Loops
            //Q1.Print Even & odd numbers from 1 to 100.
            for(int i = 1; i<=100; i++)
            {
                if (i % 2 == 0) Console.WriteLine(i + " is even number");
                else Console.WriteLine(i + " is odd number");
            }

        }
    }
}
