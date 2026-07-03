using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetTraning
{
    
    public class ClassAndObjects
    {
        public string Brand;
        public string Color;
        public int speed;

        public ClassAndObjects()
        {
            Console.WriteLine("The new Brand car");
        }
        public void Start()
        {
            Console.WriteLine("New " + Brand + " Car");
        }
        public void Accelerate()
        {
            Console.WriteLine("The speed of the " + Brand + " is " + speed);
        }
    }
}
