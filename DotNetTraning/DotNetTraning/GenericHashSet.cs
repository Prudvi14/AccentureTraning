using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetTraning
{
    public class GenericHashSet
    {
        public static void show()
        {
            HashSet<string> cities = new HashSet<string>();

            // Add
            cities.Add("Hyderabad");
            cities.Add("Mumbai");
            cities.Add("Delhi");
            cities.Add("Hyderabad");  
            cities.Add("Mumbai");    

            Console.WriteLine("count: "+cities.Count);

            // Contains
            Console.WriteLine("");
            Console.WriteLine(cities.Contains("Mumbai"));

            // Remove
            cities.Remove("Delhi");


            // Loop
            Console.WriteLine("");
            foreach (string city in cities)
                Console.WriteLine(city);

            // Union — all items from both sets
            HashSet<int> set1 = new HashSet<int>() { 1, 2, 3, 4, 5 };
            HashSet<int> set2 = new HashSet<int>() { 4, 5, 6, 7, 8 };
            Console.WriteLine("");
            set1.UnionWith(set2);
            foreach (int i in set1) Console.WriteLine(i);

            // Intersection — common items only
            HashSet<int> setA = new HashSet<int>() { 1, 2, 3, 4, 5 };
            HashSet<int> setB = new HashSet<int>() { 4, 5, 6, 7, 8 };
            Console.WriteLine("");
            setA.IntersectWith(setB);
            foreach (int i in setA) Console.WriteLine(i);

            // Difference — items in setA but not in setB
            HashSet<int> setX = new HashSet<int>() { 1, 2, 3, 4, 5 };
            HashSet<int> setY = new HashSet<int>() { 4, 5, 6, 7, 8 };
            Console.WriteLine("");
            setX.ExceptWith(setY);
            foreach (int i in setX) Console.WriteLine(i);
        }
    }
}
