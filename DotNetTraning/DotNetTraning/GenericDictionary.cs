using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetTraning
{
    public class GenericDictionary
    {
        public static void show()
        {
            Dictionary<string, int> marks = new Dictionary<string, int>();
            marks.Add("Prudvi", 95);
            marks.Add("Ravi", 88);
            marks.Add("Kumar", 92);
            marks.Add("Suresh", 88);

            Console.WriteLine("count: "+marks.Count);

            Console.WriteLine("\n"+marks["Prudvi"]);

            marks["Prudvi"] = 99;
            Console.WriteLine("\n"+marks["Prudvi"]);

            if (marks.ContainsKey("Ravi"))
                Console.WriteLine("\nRavi found!");

            if (marks.ContainsValue(88))
                Console.WriteLine("\n88 marks found!");

            marks.Remove("Kumar");

            Console.WriteLine("");
            foreach (KeyValuePair<string, int> item in marks)
                Console.WriteLine(item.Key + " : " + item.Value);

            // Loop using var (simpler)
            Console.WriteLine("");
            foreach (var item in marks)
                Console.WriteLine(item.Key + " : " + item.Value);

            // Get all keys
            Console.WriteLine("");
            foreach (string key in marks.Keys)
                Console.WriteLine("Key: " + key);

            // Get all values
            Console.WriteLine("");
            foreach (int value in marks.Values)
                Console.WriteLine("Value: " + value);
        }
    }
}
