using System;

namespace AccessSpecifierDemo1
{
    public class Program
    {
        public void Show1()
        {
            Console.WriteLine("This is a public method");
        }
        internal void Show2()
        {
            Console.WriteLine("This is a internal method");
        }
        private void Show3()
        {
            Console.WriteLine("This is a private method");
        }
        protected void Show4()
        {
            Console.WriteLine("This is a protected method");
        }
        private protected void Show5()
        {
            Console.WriteLine("This is a private protected method");
        }
        protected internal void Show6()
        {
            Console.WriteLine("This is a protected internal method");
        }
        static void Main()
        {
            Program p1= new Program();
            p1.Show1(); p1.Show2(); p1.Show3();
            p1.Show4(); p1.Show5(); p1.Show6();
        }
    }
}