using CafeteriaApp.Models;
using CafeteriaApp.Services;
using System;

namespace CafeteriaApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OrderManager manager = new OrderManager();
            int nextOrderId = 1;
            int choice;

            do
            {
                Console.WriteLine("\n=== COMPANY CAFETERIA SYSTEM ===");
                Console.WriteLine("1. Show Menu");
                Console.WriteLine("2. Place Order");
                Console.WriteLine("3. View All Orders");
                Console.WriteLine("4. Search Order");
                Console.WriteLine("5. Cancel Order");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                    continue;

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\n--- CAFETERIA MENU ---");
                        foreach (var item in manager.ShowMenu())
                            Console.WriteLine(item);
                        break;

                    case 2:
                        Console.Write("Enter Employee Name: ");
                        string name = Console.ReadLine();

                        Console.WriteLine("\n--- CAFETERIA MENU ---");
                        foreach (var item in manager.ShowMenu())
                            Console.WriteLine(item);

                        while (true)
                        {
                            Console.Write("Enter Item ID to add (0 to finish): ");

                            if (!int.TryParse(Console.ReadLine(), out int id) || id < 0)
                            {
                                Console.WriteLine("Invalid input.");
                                continue;
                            }

                            if (id == 0)
                                break;

                            if (manager.PlaceOrder(id, name))
                            {
                                Console.WriteLine($"Item added to order for {name}!");
                            }
                            else
                            {
                                Console.WriteLine("Item not found.");
                            }
                        }

                        var allOrders = manager.GetOrders();
                        var empOrder = allOrders
                            .LastOrDefault(o => o.EmployeeName == name);

                        if (empOrder != null)
                            Console.WriteLine($"\nOrder Placed: {empOrder}");

                        break;

                    case 3:
                        Console.WriteLine("\n--- ALL ORDERS ---");
                        var orders = manager.GetOrders();

                        if (orders.Count == 0)
                        {
                            Console.WriteLine("No orders found.");
                            break;
                        }

                        foreach (var ord in orders)
                            Console.WriteLine(ord);
                        break;

                    case 4:
                        Console.Write("Enter Order ID: ");
                        var result = manager.SearchOrder(
                            int.Parse(Console.ReadLine()));

                        if (result != null)
                            Console.WriteLine($"{result}");
                        else
                            Console.WriteLine("Order not found");
                        break;

                    case 5:
                        Console.Write("Enter Order ID to cancel: ");
                        if (manager.CancelOrder(
                            int.Parse(Console.ReadLine())))
                            Console.WriteLine("Order cancelled");
                        else
                            Console.WriteLine("Order not found");
                        break;

                    case 0:
                        Console.WriteLine("Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

            } while (choice != 0);
        }
    }
}