using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqProject
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public double Marks { get; set; }
    }

    public class LINQWithObjects
    {
        public static void showResult()
        {
            List<Student> students = new List<Student>()
            {
                new Student {Id=1, Name="Prudvi", Age=21, City="Hyderabad", Marks=95},
                new Student {Id=2, Name="Ravi",   Age=22, City="Mumbai",    Marks=88},
                new Student {Id=3, Name="Kumar",  Age=21, City="Hyderabad", Marks=92},
                new Student {Id=4, Name="Arun",   Age=23, City="Delhi",     Marks=78},
                new Student {Id=5, Name="Suresh", Age=22, City="Mumbai",    Marks=85},
            };

            // Select ALL students
            Console.WriteLine("=== ALL STUDENTS ===");
            var result = from s in students select s;
            foreach (var i in result)
                Console.WriteLine(i.Name);

            // Filter — Hyderabad students
            Console.WriteLine("\n=== HYDERABAD STUDENTS ===");
            var hydStudents = from s in students
                              where s.City == "Hyderabad"
                              select s;
            foreach (var i in hydStudents)
                Console.WriteLine("Name: "+i.Name+" City: "+i.City);

            // Order by marks
            Console.WriteLine("\n=== ORDERED BY MARKS ===");
            var ordered = from s in students
                          orderby s.Marks descending
                          select s;
            foreach (var i in ordered)
                Console.WriteLine("Name: "+i.Name+" Marks: "+i.Marks);
        }
    }
}