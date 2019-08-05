using System;
using Vavatech.TrackingSystem.Models;

namespace Vavatech.TrackingSystem.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello in Tracking System!");

            Product product = new Product(1, "Domofon", "123456");

            Order order = new Order(product, 5)
            {
                Id = 1, 
            };

            Console.WriteLine($"Przyjęto zamówienie na {order.Product.Name} w ilości: {order.Quantity}");
        }
    }
}
