using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DotNetTraning
{
    public class GenericStack
    {
        public static void show()
        {
            Stack<string> stack = new Stack<string>();

            // Push 
            stack.Push("Page1");
            stack.Push("Page2");
            stack.Push("Page3");
            stack.Push("Page4");
            stack.Push("Page5");
            stack.Push("Page6");

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
            stack.Push("Home");
            stack.Push("About");
            Console.WriteLine("");
            Console.WriteLine(stack.Contains("Home"));

            // Loop 
            foreach (string item in stack)
                Console.WriteLine(item);

            // Clear
            stack.Clear();
        }
    }
}
