using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DotNetTraning
{
    public class ArrayListCollections
    {
        public static void show()
        {
            ArrayList list = new ArrayList();
            list.Add("Gadeshula");
            list.Add("Prudvi");
            list.Add(22);
            list.Add(true);
            list.Add(175.50);

            Console.WriteLine("");
            Console.WriteLine("Total items in List: "+list.Count);
            foreach (object i in list) Console.WriteLine(i);

            list.RemoveAt(0);
            list.Insert(0, "Hello");
            //list.Sort();
            Console.WriteLine("");
            Console.WriteLine(list.Contains(true));

            Console.WriteLine("");
            Console.WriteLine("Items after Some operations: ");
            foreach (object i in list) Console.WriteLine(i);

            Console.WriteLine("");
            list.Clear();

            Console.WriteLine("");
            Console.WriteLine("final count after clearing list: "+ list.Count);
        }
    }
}
