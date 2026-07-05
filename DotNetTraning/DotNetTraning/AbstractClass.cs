using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetTraning
{
    abstract class NewVehicle
    {
        public string Brand;
        public int Speed;

        // Abstract class CAN have constructor!
        public NewVehicle(string brand, int speed)
        {
            Brand = brand;
            Speed = speed;
        }
        // Abstract method — child MUST implement
        public abstract string GetType();

        // Normal method
        public void ShowInfo()
        {
            Console.WriteLine($"Brand: {Brand}");
            Console.WriteLine($"Speed: {Speed}");
            Console.WriteLine($"Type: {GetType()}");
        }
    }
    class NewCar : NewVehicle
    {
        public int Doors;

        public NewCar(string brand, int speed, int doors)
            : base(brand, speed)    // calling parent constructor
        {
            Doors = doors;
        }

        public override string GetType()
        {
            return "Car with " + Doors + " doors";
        }
    }
    class NewBike : NewVehicle
    {
        public bool HasGear;

        public NewBike(string brand, int speed, bool hasGear)
            : base(brand, speed)
        {
            HasGear = hasGear;
        }

        public override string GetType()
        {
            return "Bike, Gear: " + HasGear;
        }
    }
}
