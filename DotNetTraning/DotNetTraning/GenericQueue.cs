using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DotNetTraning
{
    public class GenericQueue
    {
        public static void show()
        {
            Queue<string> queue = new Queue<string>();

            // Enqueue
            queue.Enqueue("Order1");
            queue.Enqueue("Order2");
            queue.Enqueue("Order3");
            queue.Enqueue("Order4");
            queue.Enqueue("Order5");
            queue.Enqueue("Order6");

            // Count
            Console.WriteLine(queue.Count);

            // Peek 
            Console.WriteLine(queue.Peek());

            // Dequeue 
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());

            Console.WriteLine(queue.Count);

            // Contains
            queue.Enqueue("Task1");
            queue.Enqueue("Task2");
            Console.WriteLine(queue.Contains("Task1"));

            // Loop
            foreach (string item in queue)
                Console.WriteLine(item);

            // Clear
            queue.Clear();
        }
    }
}
