using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DotNetTraning
{
    public class SortedListCollections
    {
        public static void show()
        {
            SortedList sortedList = new SortedList();

            // Add key-value pairs
            sortedList.Add("Banana", 30);
            sortedList.Add("Apple", 50);
            sortedList.Add("Mango", 20);
            sortedList.Add("Cherry", 40);

            // Access by key
            Console.WriteLine(sortedList["Apple"]);   
            Console.WriteLine(sortedList["Mango"]);   

            // Access by index
            Console.WriteLine(sortedList.GetByIndex(0));  

            // Get key at index
            Console.WriteLine(sortedList.GetKey(0));      

            // Count
            Console.WriteLine(sortedList.Count);  

            // Contains key
            Console.WriteLine(sortedList.ContainsKey("Mango"));   
            Console.WriteLine(sortedList.ContainsValue(30));       

            // Loop 
            foreach (DictionaryEntry entry in sortedList)
            {
                Console.WriteLine(entry.Key + " : " + entry.Value);
            }
        }
    }
}
