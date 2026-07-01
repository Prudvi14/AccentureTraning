using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DotNetTraning
{
    public class QueueCollections
    {
        public static void show()
        {
            Queue queue = new Queue();

            // Enqueue
            queue.Enqueue("Person1");
            queue.Enqueue(2);
            queue.Enqueue(true);
            queue.Enqueue("Person4");

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
            foreach (object item in queue)
                Console.WriteLine(item);

            // Clear
            queue.Clear();
        }
    }
}
