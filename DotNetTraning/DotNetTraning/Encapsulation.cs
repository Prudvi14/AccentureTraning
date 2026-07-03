using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetTraning
{
    public class Encapsulation
    {
        //public string name;
        //private int age;
        //protected double marks;

        //public void setName(string n)
        //{
        //    if (n != "") name = n;
        //    else Console.WriteLine("Name can not be empty");
        //}
        //public string GetName()
        //{
        //    return name;
        //}
        //public void setAge(int a)
        //{
        //    if (a>0 && a<100) age = a;
        //    else Console.WriteLine("age should be in 0-100 range");
        //}
        //public int GetAge()
        //{
        //    return age;
        //}
        //public void setMarks(double m)
        //{
        //    if (m >= 0 && m <= 100) marks = m;
        //    else Console.WriteLine("marks must be between 0 to 100!");
        //}
        //public double GetMarks()
        //{
        //    return marks;
        //}


        //private string name;
        //private int age;
        //private double marks;
        //public string Name
        //{
        //    get
        //    {
        //        return name;
        //    }
        //    set
        //    {
        //        if (value != "") name = value;
        //        else Console.WriteLine("Name cannot be empty!");
        //    }
        //}
        //public int Age
        //{
        //    get
        //    {
        //        return age;
        //    }
        //    set
        //    {
        //        if (value > 0 && value < 100) age = value;
        //        else Console.WriteLine("Invalid age!");
        //    }
        //}
        //public double Marks
        //{
        //    get
        //    {
        //        return marks;
        //    }
        //    set
        //    {
        //        if (value >= 0 && value <= 100) marks = value;
        //        else Console.WriteLine("Marks must be 0 to 100!");
        //    }
        //}



        public string Name { get; set; }
        public int Age { get; set; }
        public double Marks { get; set; }
        public string School { get; } = "ABC School";
    }
}
