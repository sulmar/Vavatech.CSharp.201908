using System;
using Vavatech.TrackingSystem.Models;

namespace Vavatech.TrackingSystem.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello in Tracking System!");

            Part part1 = new Part(1, "Ekran LCD", 19.99m);
            Part part2 = new Part(2, "Klawiatura", 10);

            Product product = new Product(1, "Domofon", "123456");

            product.Parts.Add(part1);
            product.Parts.Add(part2);

            Order order = new Order(product, 5)
            {
                Id = 1, 
            };

            order.Print();

            Console.WriteLine(part1.ToString());

         //   Console.WriteLine($"Przyjęto zamówienie na {order.Product.Name} w ilości: {order.Quantity}");
        }
    }
}
