using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DotNetTraning
{
    public class StackCollections
    {
        public static void show()
        {
            Stack stack = new Stack();

            // Push 
            stack.Push(10);
            stack.Push("Prudvi");
            stack.Push(true);
            stack.Push(99.99);

            // Count
            Console.WriteLine(stack.Count);   

            // Peek
            Console.WriteLine(stack.Peek());  

            // Pop
            Console.WriteLine(stack.Pop());  
            Console.WriteLine(stack.Pop());  
            Console.WriteLine(stack.Pop()); 
            Console.WriteLine(stack.Pop());  

            Console.WriteLine(stack.Count);   

            // Contains
            stack.Push("Hello");
            stack.Push("World");
            Console.WriteLine("");
            Console.WriteLine(stack.Contains("Hello")); 

            // Loop 
            foreach (object item in stack)
                Console.WriteLine(item);

            // Clear
            stack.Clear();
        }
    }
}
