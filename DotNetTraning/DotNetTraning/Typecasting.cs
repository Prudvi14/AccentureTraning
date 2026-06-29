using System;

namespace DotNetNewProject
{
    internal class TypeCasting
    {
        public static void ShowTypeCasting()
        {
            Console.WriteLine("Implicit converstion");
            int num = 21;
            Console.WriteLine("int num: " + num);
            float f = num;
            Console.WriteLine("float f: " + f);
            double result = f;
            Console.WriteLine("double result: " + result);

            Console.WriteLine('\n');
            Console.WriteLine("Explicit converstion");
            double price = 21.22;
            Console.WriteLine("double price: " + price);
            int round = (int)price;
            Console.WriteLine("int round: " + round);


            Console.WriteLine('\n');
            Console.WriteLine("Parse convertion");
            string age = "21";
            int num1 = int.Parse(age);
            Console.WriteLine(num1 + 1);
            string price1 = "99.99";
            double d = double.Parse(price1);
            Console.WriteLine(d + 1);
            string flag = "true";
            bool b = bool.Parse(flag);
            Console.WriteLine(b);


            Console.WriteLine('\n');
            Console.WriteLine("Convert ");
            string age2 = "21";
            int num2 = Convert.ToInt32(age2);
            Console.WriteLine(num2);
            string price2 = "99.99";
            double d2 = Convert.ToDouble(price2);
            Console.WriteLine(d2);


            Console.WriteLine('\n');
            Console.WriteLine("TryParse convertion");
            string validInput = "100";
            bool success = int.TryParse(validInput, out int answer);
            if (success) Console.WriteLine("Converted: " + answer);
            else Console.WriteLine("Failed!");
        }
    }
}
