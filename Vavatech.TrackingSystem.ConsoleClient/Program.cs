using System;
using System.Collections.Generic;
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

            List<Part> parts = new List<Part>
            {
                part1,
                part2
            };

           Item item = new Product(1, "Domofon", "123456", parts);

            //Item item = new Service(1, "Instalacja software", 100);

            Console.WriteLine(item.Calculate());

            Console.WriteLine(item.ToString());

        
            Order order = new Order(item, 5)
            {
                Id = 1, 
            };

            order.Status = OrderStatus.Created;

            Console.WriteLine(order);


         //   Console.WriteLine($"Przyjęto zamówienie na {order.Product.Name} w ilości: {order.Quantity}");
        }
    }
}
