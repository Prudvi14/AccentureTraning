using System;
using System.Collections.Generic;
using System.Text;

namespace LinqProject
{
    public class LinqBasics
    {
        public static void show()
        {
            Console.WriteLine("=== WHERE (Filter) ===");
            List<int> num = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            Console.WriteLine("\n\nEven numbers:");
            var even = from s in num 
                       where s % 2 == 0 
                       select s;
            foreach(int i in even) Console.Write(i + "\t");

            Console.WriteLine("\n\nOdd numbers:");
            var odd = num.Where(n => n % 2 != 0).ToList();
            foreach (int i in odd) Console.Write(i + "\t");

            Console.WriteLine("\n\nnumbers between 5 to 10:");
            var r = num.Where(n => n > 5 && n < 10).ToList();
            foreach(var i in r) Console.Write(i + "\t");

            Console.WriteLine("\n\nMultiplication with 10: ");
            var m = num.Select(n => n * 10).ToList();
            foreach(var i in m) Console.Write(i+"\t");



            Console.WriteLine("\n\n\n\n=== SELECT (Transform) ===");
            List<string> names = new List<string>() { "prudvi", "ravi", "kumar", "Arun"};
            Console.WriteLine("\n\nTo Upper case");
            var u = names.Select(n => n.ToUpper()).ToList();
            foreach(var i in u) Console.Write(i + "\t");



            Console.WriteLine("\n\n\n\n=== ORDERBY (Sort) ===");
            List<int> numbers = new List<int>() { 5, 2, 8, 1, 9, 3, 7, 4, 6 };
            Console.WriteLine("\n\nAscending Order");
            var asc = numbers.OrderBy(n => n).ToList();
            foreach(var i in asc) Console.Write(i + "\t");

            Console.WriteLine("\n\nDescending Order");
            var desc = numbers.OrderByDescending(n => n).ToList();
            foreach (var i in desc) Console.Write(i + "\t");

            Console.WriteLine("\n\nSorting String");
            List<string> names1 = new List<string>() { "prudvi", "ravi", "kumar", "Arun" };
            var sname = names1.OrderBy(n => n).ToList();
            foreach (var i in sname) Console.Write(i + "\n");



            Console.WriteLine("\n\n\n\n=== DISTINCT (Remove Duplicates) ===");
            List<int> numbers2 = new List<int>() { 1, 2, 2, 3, 3, 3, 4, 5, 5 };
            var unique = numbers2.Distinct().ToList();
            Console.WriteLine("\n\nUnique numbers:");
            foreach (var n in unique)
                Console.WriteLine(n);
        }
    }
}
