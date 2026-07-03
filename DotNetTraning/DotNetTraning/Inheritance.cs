using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetTraning
{
    public class A
    {
        public void methodA()
        {
            Console.WriteLine("This is method A");
        }
    }
    public class B:A
    {
        public void methodB()
        {
            Console.WriteLine("This is method B");
        }
    }
    public class C : B
    {
        public void methodC()
        {
            Console.WriteLine("This is method C");
        }
    }

    class Vehicle      
    {
        public string Brand;
        public int Speed;
        public void ShowInfo()
        {
            Console.WriteLine($"Brand: {Brand}, Speed: {Speed}");
        }
    }

    class Car : Vehicle{
        public int Doors;
        public void ShowCar(){
            Console.WriteLine($"Car with {Doors} doors");
        }
    }
    class Bike : Vehicle    
    {
        public bool HasSidecar;
        public void ShowBike()
        {
            Console.WriteLine($"Bike, Sidecar: {HasSidecar}");
        }
    }
}
