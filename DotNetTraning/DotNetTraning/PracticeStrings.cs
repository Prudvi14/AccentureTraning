using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace DotNetTraning
{
    public class PracticeStrings
    {
        public static void stringsPractice()
        {
            string fname = "Gadeshula ";
            string mname = "prudvi ";
            string name = fname + mname; //string concatination using +
            string fullname = string.Concat(name,"Chowdary"); //string concatination using .concat()
            int size = name.Length;
            Console.WriteLine("my name: " + name + " length is: "+size); 

            string final = $"My full name is: {fullname}"; //string interpolation
            Console.WriteLine(final);

            Console.WriteLine("\n");
            Console.WriteLine(name.ToUpper());   
            Console.WriteLine(name.ToLower());

            Console.WriteLine("\n");
            Console.WriteLine(fullname.IndexOf('p'));

            Console.WriteLine("\n");
            int Charat = name.IndexOf('p');
            string nickName = name.Substring(Charat);
            Console.WriteLine(nickName);

            Console.WriteLine("\n");
            for (int i=0; i<fullname.Length; i++)
            {
                Console.WriteLine(fullname[i]+" : "+i);
            }
        }

    }
}
