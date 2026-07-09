using CafeteriaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaApp.Services
{
    public class OrderManager
    {
        private Dictionary<int, MenuItem> menu = new Dictionary<int, MenuItem>();
        private List<Order> orders = new List<Order>();
        private int nextOrderId = 1;

        public OrderManager()
        {
            menu.Add(1, new MenuItem(1, "Coffee", 2.5));
            menu.Add(2, new MenuItem(2, "Sandwich", 4.0));
            menu.Add(3, new MenuItem(3, "Pasta", 6.0));
            menu.Add(4, new MenuItem(4, "Juice", 3.0));
            menu.Add(5, new MenuItem(5, "Salad", 3.5));
        }

        public List<MenuItem> ShowMenu()
        {
            return menu.Values.ToList();
        }

        public bool PlaceOrder(int itemId, string name)
        {
            if (!menu.ContainsKey(itemId))
                return false;

            Order existingOrder = orders
                .FirstOrDefault(o => o.EmployeeName == name);

            if (existingOrder != null)
            {
                existingOrder.Items.Add(menu[itemId]);
                existingOrder.CalculateTotal();
            }
            else
            {
                Order newOrder = new Order(nextOrderId++, name);
                newOrder.Items.Add(menu[itemId]);
                newOrder.CalculateTotal();
                orders.Add(newOrder);
            }

            return true;
        }

        public Order SearchOrder(int id)
        {
            return orders.FirstOrDefault(o => o.OrderId == id);
        }

        public bool CancelOrder(int id)
        {
            Order order = orders.FirstOrDefault(o => o.OrderId == id);

            if (order == null)
                return false;

            orders.Remove(order);
            return true;
        }

        public List<Order> GetOrders()
        {
            return orders;
        }

        public void AddOrderForTest(string name, List<int> itemIds)
        {
            Order order = new Order(nextOrderId++, name);

            foreach (int id in itemIds)
            {
                if (menu.ContainsKey(id))
                    order.Items.Add(menu[id]);
            }

            order.CalculateTotal();
            orders.Add(order);
        }
    }
}