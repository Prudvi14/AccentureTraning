using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DotNetTraning
{
    public class HashtableCollections
    {
        public static void show()
        {
            Hashtable table = new Hashtable();

            // Add key-value pairs
            table.Add("Name", "Prudvi");
            table.Add("Age", 21);
            table.Add("City", "Hyderabad");
            table.Add(1, "One");           
            table.Add(2, true);            

            // Access by key
            Console.WriteLine(table["Name"]);   
            Console.WriteLine(table["Age"]);   
            Console.WriteLine(table[1]);        

            // Check if key exists
            if (table.ContainsKey("Name"))
                Console.WriteLine("Name exists!");

            // Check if value exists
            if (table.ContainsValue("Prudvi"))
                Console.WriteLine("Prudvi found!");

            // Remove by key
            table.Remove("City");

            // Update value
            table["Age"] = 22;

            // Count
            Console.WriteLine(table.Count);  

            // Loop through
            foreach (DictionaryEntry entry in table)
            {
                Console.WriteLine(entry.Key + " : " + entry.Value);
            }

            // Clear
            table.Clear();
        }
    }
}
