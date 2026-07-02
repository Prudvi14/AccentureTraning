using System;
using System.Collections.Generic;
using System.Text;

namespace LinqProject
{
    public class AggregateLINQ
    {
        public static void show()
        {
            Console.WriteLine("=== AGGREGATE FUNCTIONS ===");

            List<int> numbers = new List<int>()
            { 10, 20, 30, 40, 50 };

            // Elements
            Console.Write("Elements are: ");
            foreach (var i in numbers) Console.Write(i+"\t");

            // Count
            int count = numbers.Count();
            Console.WriteLine("\nCount: " + count);      

            // Sum
            int sum = numbers.Sum();
            Console.WriteLine("Sum: " + sum);          

            // Average
            double avg = numbers.Average();
            Console.WriteLine("Average: " + avg);      

            // Max
            int max = numbers.Max();
            Console.WriteLine("Max: " + max);         

            // Min
            int min = numbers.Min();
            Console.WriteLine("Min: " + min);           

            // Count with condition
            int countAbove20 = numbers.Count(n => n > 20);
            Console.WriteLine("Count above 20: " + countAbove20); 

            // Sum with condition
            int sumAbove20 = numbers.Where(n => n > 20).Sum();
            Console.WriteLine("Sum above 20: " + sumAbove20);



            Console.WriteLine("\n\n\n\n=== FIRST & LAST ===");

            // First
            Console.WriteLine("First: " + numbers.First());        

            // First with condition
            Console.WriteLine("First > 25: " + numbers.First(n => n > 25));  

            // Last
            Console.WriteLine("Last: " + numbers.Last());       

            // Last with condition
            Console.WriteLine("Last < 40: " + numbers.Last(n => n < 40));   

            // FirstOrDefault — returns 0 if not found
            Console.WriteLine("FirstOrDefault > 100: " +
                numbers.FirstOrDefault(n => n > 100));             

            // Single — returns exactly ONE result
            // throws exception if 0 or more than 1 found
            Console.WriteLine("Single == 30: " +
                numbers.Single(n => n == 30));



            Console.WriteLine("\n\n\n\n=== ANY & ALL ===");
            // Any — is there at least ONE matching item?
            bool anyAbove40 = numbers.Any(n => n > 40);
            Console.WriteLine("Any above 40: " + anyAbove40);  // True

            bool anyAbove100 = numbers.Any(n => n > 100);
            Console.WriteLine("Any above 100: " + anyAbove100); // False

            // All — do ALL items match?
            bool allAbove5 = numbers.All(n => n > 5);
            Console.WriteLine("All above 5: " + allAbove5);    // True

            bool allAbove20 = numbers.All(n => n > 20);
            Console.WriteLine("All above 20: " + allAbove20);  // False
        }
    }
}
