using System;
using System.Collections.Generic;
using Vavatech.TrackingSystem.Models;

namespace Vavatech.TrackingSystem.ConsoleClient
{
    partial class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello in Tracking System!");

            // CreateOrderTest();

            //List<Customer> customers = new List<Customer>()
            //{
            //    new Customer (1, "John", "Smith"),
            //    new Customer (2, "Ann", "Smith"),
            //    new Customer (3, "Peter", "Novak"),
            //};

            //CustomersLoader customersLoader = new CustomersLoader();

            //List<Customer> customers = customersLoader.Load("customers.txt");

            ICustomerRepository customerRepository = new FileCustomerRepository("customers.txt");

            List<Customer> customers = customerRepository.Get();

            customers.Remove(customers[1]);

            foreach (Customer customer in customers)
            {
                Console.WriteLine(customer);
            }



            //   Console.WriteLine($"Przyjęto zamówienie na {order.Product.Name} w ilości: {order.Quantity}");
        }

        private static void CreateOrderTest()
        {
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

            Customer customer = new Customer(1, "Marcin", "Sulecki")
            {
                HomeAddress = new Address("Warszawa", "Powst. Śląskich", "01466"),
                WorkAddress = new Address("Warszawa", "Olesińska", "01100")
            };

            Order order = new Order(item, customer, 5)
            {
                Id = 1,
            };

            order.Status = OrderStatus.Created;

            Console.WriteLine(order);
        }
    }
}
