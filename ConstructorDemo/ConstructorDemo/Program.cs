using System;
namespace Constructor
{
    class Program
    {
        int x, y;
        static Program()
        {
            Console.WriteLine("This is static Constructor");
        }
        public Program()
        {
            Console.WriteLine("This is a default constructor");
        }
        public Program(int x, int y)
        {
            this.x = x;
            this.y = y;
            Console.WriteLine($"Paramaterised and Addition of x and y is : {x + y}");
        }
        public Program(Program p)
        {
            this.x=p.x;
            this.y=p.y;
            Console.WriteLine("This is a copy Constructor");
        }
        static void Main()
        {
            Console.WriteLine("This is main method");
            Program p1 = new Program();
            Program p2 = new Program(10, 20);
            Program p3 = new Program(p2);
        }
    }
}