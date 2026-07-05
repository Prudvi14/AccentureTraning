using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetTraning
{
    interface IPayment
    {
        void MakePayment(double amount);
        bool VerifyPayment();
        void ShowReceipt();
    }
    class CreditCard : IPayment
    {
        public void MakePayment(double amount)
        {
            Console.WriteLine($"Paid {amount} via Credit Card");
        }

        public bool VerifyPayment()
        {
            Console.WriteLine("Credit Card verified!");
            return true;
        }

        public void ShowReceipt()
        {
            Console.WriteLine("Credit Card receipt generated!");
        }
    }
    class UPI : IPayment
    {
        public void MakePayment(double amount)
        {
            Console.WriteLine($"Paid {amount} via UPI");
        }

        public bool VerifyPayment()
        {
            Console.WriteLine("UPI verified!");
            return true;
        }

        public void ShowReceipt()
        {
            Console.WriteLine("UPI receipt generated!");
        }
    }
    class NetBanking : IPayment
    {
        public void MakePayment(double amount)
        {
            Console.WriteLine($"Paid {amount} via Net Banking");
        }

        public bool VerifyPayment()
        {
            Console.WriteLine("Net Banking verified!");
            return true;
        }

        public void ShowReceipt()
        {
            Console.WriteLine("Net Banking receipt generated!");
        }
    }
}
