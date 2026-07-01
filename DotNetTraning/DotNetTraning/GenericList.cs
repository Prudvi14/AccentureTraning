using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetTraning
{
    public class GenericList
    {
        public static void show()
        {
            List<string> names = new List<string>();
            names.Add("Prudvi");
            names.Add("Ravi");
            names.Add("Kumar");
            names.Add("Suresh");

            Console.WriteLine(names[0]);

            Console.WriteLine("");
            Console.WriteLine("count: "+names.Count);

            Console.WriteLine("");
            Console.WriteLine(names.Contains("Ravi")); 

            Console.WriteLine("");
            Console.WriteLine(names.IndexOf("Kumar"));

            Console.WriteLine("");
            names.Insert(4, "Mahesh");  
            Console.WriteLine(names[4]);

            names.Remove("Ravi");

            names.RemoveAt(1);

            names.Sort();
            Console.WriteLine("");
            Console.WriteLine("After Sort:");
            foreach (string name in names) Console.WriteLine(name);

            names.Reverse();
            Console.WriteLine("");
            Console.WriteLine("After Reverse:");
            foreach (string name in names) Console.WriteLine(name);

            string[] arr = names.ToArray();

            names.Clear();
            Console.WriteLine("");
            Console.WriteLine(names.Count);
        }
    }
}
