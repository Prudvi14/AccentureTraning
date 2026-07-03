using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetTraning
{
    public class Box
    {
        public int Length;
        public int Width;
        public Box(int l, int w){
            Length = l;
            Width = w;
        }
        // Overload + operator
        public static Box operator +(Box b1, Box b2)
        {
            return new Box(
                b1.Length + b2.Length,
                b1.Width + b2.Width
            );
        }
        public void ShowSize()
        {
            Console.WriteLine($"Length: {Length}, Width: {Width}");
        }
    }
}
