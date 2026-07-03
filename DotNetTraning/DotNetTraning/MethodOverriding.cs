using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetTraning
{
    class Animal
    {
        public virtual void MakeSound()
        {
            Console.WriteLine("Animal makes a sound!");
        }
    }

    class Dog : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Dog says: Woof Woof!");
        }
    }
    class Cat : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Cat says: Meow Meow!");
        }
    }

    class Bird : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Bird says: Tweet Tweet!");
        }
    }
}
