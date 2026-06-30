using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetTraning
{
    public class UserInput
    {
        public static void GetUser()
        {
            Console.WriteLine("Enter your Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your Age: ");
            int Age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your Gender: ");
            string Gender = Console.ReadLine();
            GetInfo(name, Age, Gender);
        }
        public static void GetInfo(String name, int Age, String Gender)
        {
            Console.WriteLine("My name is: " + name + " and i am " + Age + " old");
            Console.WriteLine("i am a " + Gender);
        }
    }
}
