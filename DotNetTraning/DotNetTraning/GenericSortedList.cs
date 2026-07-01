using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DotNetTraning
{
    public class GenericSortedList
    {
        public static void show()
        {
            SortedList<string, int> sortedMarks = new SortedList<string, int>();

            // Add key-value pairs
            sortedMarks.Add("Ravi", 88);
            sortedMarks.Add("Prudvi", 95);
            sortedMarks.Add("Kumar", 92);
            sortedMarks.Add("Arun", 78);

            // Access by key
            Console.WriteLine(sortedMarks["Prudvi"]);
            Console.WriteLine(sortedMarks["Arun"]);

            // Access by index
            foreach (var item in sortedMarks) Console.WriteLine(item.Key + " : " + item.Value);

            // Access by index
            Console.WriteLine(sortedMarks.Keys[0]);    
            Console.WriteLine(sortedMarks.Values[0]);
        }
    }
}
