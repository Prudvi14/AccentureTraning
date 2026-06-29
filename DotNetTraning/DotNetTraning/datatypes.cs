using System;
namespace DotNetNewProject
{
    class DataTypes
    {
        public static void ShowDataTypes()
        {
            string name = "Prudvi";
            int age = 22;
            char grade = 'A';
            bool isStudent = true;
            double height = 175.5;
            string fullname = "Gadeshula " + name;

            Console.WriteLine("name: " + name);
            Console.WriteLine("Full name: " + fullname);
            Console.WriteLine("age: " + age);
            Console.WriteLine("height: " + height);
            Console.WriteLine("grade: " + grade);
            Console.WriteLine("isStudent: " + isStudent);


            Console.WriteLine("Special type of Datatypes");
            Console.WriteLine("1.Var: ");
            var Myname = "prudvi";
            Console.WriteLine("Myname: " + Myname);
            Myname = "Gadeshula Prudvi";
            Console.WriteLine("Myname: " + Myname); ;

            Console.WriteLine("2.dynamic: ");
            dynamic Age = 21;
            Console.WriteLine("Age: " + Age);
            Age = "twenty one";
            Console.WriteLine("Age: " + Age);

            Console.WriteLine("3.Object: ");
            object obj = "prudvi";
            Console.WriteLine("obj: " + obj);
            obj = 21;
            Console.WriteLine("obj: " + obj);
            obj = true;
            Console.WriteLine("obj: " + obj);
            obj = 99.99;
            Console.WriteLine("obj: " + obj);
        }
    }
}
