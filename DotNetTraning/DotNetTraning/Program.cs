using System;

namespace DotNetTraning
{
    class Myclass
    {
        static void Main(String[] args)
        {
            //git add .
            //git commit -m ""
            //git push origin main

            //Console.WriteLine("Hello world");
            //Console.Write("Welcome");

            //DataTypes.ShowDataTypes();

            //TypeCasting.ShowTypeCasting();

            //Nullabel.ShowNullables();

            //UserInput.GetUser();

            //Functions.Getinputs();

            //PracticeStrings.stringsPractice();

            //Arrays.PracticeArrays();

            //Day1.PracticeDay();

            //ClassAndObjects c1 = new ClassAndObjects();
            //c1.Brand = "Toyata";
            //c1.Color = "White";
            //c1.speed = 160;
            //c1.Start();
            //c1.Accelerate();

            Encapsulation s= new Encapsulation();
            //s.setName("Prudvi");
            //s.setAge(21);
            //s.setMarks(95);
            //Console.WriteLine("Name is: "+s.GetName()); 
            //Console.WriteLine("Age is: "+s.GetAge()); 
            //Console.WriteLine("Marks got: "+s.GetMarks());
            //s.SetName("");      // Name cannot be empty!
            //s.SetAge(-5);       // Invalid age!
            //s.SetMarks(500);    // Marks must be between 0 and 100!

            //s.Name = "Prudvi";   
            //s.Age = 21;          
            //s.Marks = 95;        
            //Console.WriteLine(s.Name);   
            //Console.WriteLine(s.Age);    
            //Console.WriteLine(s.Marks);  

            // Invalid values — controlled!
            //s.Name = "";      
            //s.Age = -5;       
            //s.Marks = 500;    

            //single inheritance
            //B obj = new B();
            //obj.methodA();
            //obj.methodB();

            //multiple inheritance
            //C obj = new C();
            //obj.methodA();
            //obj.methodB();
            //obj.methodC();

            //heirarchical inheritance
            //Car car = new Car();
            //car.Brand = "Toyota";
            //car.Speed = 180;
            //car.Doors = 4;
            //car.ShowInfo();   
            //car.ShowCar();    
            //Bike bike = new Bike();
            //bike.Brand = "Honda";
            //bike.Speed = 120;
            //bike.HasSidecar = false;
            //bike.ShowInfo();  
            //bike.ShowBike();

            //method overloading
            //Calculator calc = new Calculator();
            //Console.WriteLine(calc.Add(10, 20));
            //Console.WriteLine(calc.Add(1.5, 2.5));
            //Console.WriteLine(calc.Add(10, 20, 30));
            //Console.WriteLine(calc.Add("Prudvi", "Ravi"));

            //operator overloading
            //Box box1 = new Box(10, 5);
            //Box box2 = new Box(20, 10);
            //Box box3 = box1 + box2;
            //box3.ShowSize();

            //method overriding
            Animal a1 = new Dog();
            Animal a2 = new Cat();
            Animal a3 = new Bird();
            a1.MakeSound();  
            a2.MakeSound(); 
            a3.MakeSound(); 
            // Array of Animals — Polymorphism power!
            Animal[] animals = {
                new Dog(),
                new Cat(),
                new Bird(),
                new Dog()
            };
            Console.WriteLine("\n=== All Animals ===");
            foreach (Animal a in animals)
                a.MakeSound();

            //Generics.addGenerics<int>(8, 9);
            //Generics.addGenerics<string>("hii ", "Prudvi");
            //Generics.addGenerics<Double>(8.75, 7.569);

            //Console.WriteLine("");
            //int maxInt = Generics.getMax<int>(10, 20);
            //Console.WriteLine("max int: " + maxInt);

            //Console.WriteLine("");
            //string maxStr = Generics.getMax<string>("Apple", "Mango");
            //Console.WriteLine("max string: " + maxStr);

            //ArrayListCollections.show();

            //HashtableCollections.show();

            //StackCollections.show();

            //QueueCollections.show();

            //SortedListCollections.show();

            //GenericList.show();

            //GenericDictionary.show();

            //GenericStack.show();

            //GenericQueue.show();

            //GenericSortedList.show();

            //GenericHashSet.show();
        }
    }
}
