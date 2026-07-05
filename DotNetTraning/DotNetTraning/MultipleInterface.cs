using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetTraning
{
    interface IFlyable
    {
        void Fly();
    }

    interface ISwimmable
    {
        void Swim();
    }

    interface IRunnable
    {
        void Run();
    }
    class Duck : IFlyable, ISwimmable, IRunnable
    {
        public void Fly()
        {
            Console.WriteLine("Duck is flying!");
        }

        public void Swim()
        {
            Console.WriteLine("Duck is swimming!");
        }

        public void Run()
        {
            Console.WriteLine("Duck is running!");
        }
    }
    class Eagle : IFlyable
    {
        public void Fly()
        {
            Console.WriteLine("Eagle is flying high!");
        }
    }
    class Fish : ISwimmable
    {
        public void Swim()
        {
            Console.WriteLine("Fish is swimming!");
        }
    }
}
