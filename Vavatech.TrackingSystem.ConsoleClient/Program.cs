using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Security.Authentication;
using Vavatech.TrackingSystem.Models;

namespace Vavatech.TrackingSystem.ConsoleClient
{
    partial class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello in Tracking System!");

            // CreateOrderTest();

            // RepositoryTest();

            // ProcessorTest();

            LinqTest();


            VarTest();

            DynamicTest();


            //   Console.WriteLine($"Przyjęto zamówienie na {order.Product.Name} w ilości: {order.Quantity}");
        }

        private static void VarTest()
        {
            var age = 10;

            var message = "Hello World";

            var sign = 'a';

            var signs = new char[] { 'a', 'b', 'c' };

            var customer = new Customer(1, "John", "Smith");


            // Typ anonimowy
            var person = new { FirstName = "Marcin", LastName = "Sulecki" };

            Console.WriteLine(person.FirstName);


            Console.WriteLine(message);
        }

        private static void DynamicTest()
        {
            dynamic customer = new Customer(1, "John", "Smith");

            Console.WriteLine(customer.FirstName);

            customer = "Janek";
        }

        private static void LinqTest()
        {
            ICustomerRepository customerRepository = new FakeCustomerRepository();

            var customers = customerRepository.Get("A");

            foreach (var cust in customers)
            {
                Console.WriteLine(cust);
            }

            var cities = customers
                .Where( c => !c.IsRemoved)
                .Select(c => new { Imie = c.FirstName, Nazwisko = c.LastName, c.HomeAddress.City });

            Customer customer = customerRepository.Get(10);

            Console.WriteLine(customer);
        }

        private static void ProcessorTest()
        {
            Order order = CreateOrderTest();

            if (order.Item is Product)
            {
                Product product = (Product) order.Item;

                List<Operation> operations = new List<Operation>
                {
                    new AssemblyOperation(),
                    new BoxOperation(),
                    new TestOperation(),
                    new MarkOperation()
                };

                Process process = new Process
                {
                    Name = "Produkcja domofonu",
                    Version = "1.0",
                    Product = product,
                    Operations = operations
                };

                Processor processor = new Processor();

                processor.OperationDone += Report;
                processor.OperationBegin += Processor_OperationBegin;


                // processor.OperationDone.Invoke();

                order.Status = OrderStatus.InProduction;

                for (int i = 0; i < order.Quantity; i++)
                {
                    processor.Make(product, process);
                }

                order.Status = OrderStatus.Done;
                order.FinishedDate = DateTime.Now;

                Console.WriteLine($"Czas realizacji: {order.Period}" );

            }
            else
            {
                Console.WriteLine("Realizacja usługi");
            }

         
        }

        private static void Processor_OperationBegin(object sender, OperationEventArgs e)
        {
            Console.WriteLine($"Data rozp. {e.BeginDate} przez {sender}");
        }

        private static void Report(string name)
       {
            Console.WriteLine($"Wykonano operację {name}.");
       }

        private static void RepositoryTest()
        {
            IItemRepository itemRepository = new FileItemRepository("items.txt");

            List<Item> items = itemRepository.Get();

            //CustomersLoader customersLoader = new CustomersLoader();

            //List<Customer> customers = customersLoader.Load("customers.txt");

            // ICustomerRepository customerRepository = new FileCustomerRepository("customers.txt");
            ICustomerRepository customerRepository = new FakeCustomerRepository();

            List<Customer> customers = customerRepository.Get();

            customers.Remove(customers[1]);

            foreach (Customer customer in customers)
            {
                Console.WriteLine(customer);
            }
        }

        private static Order CreateOrderTest()
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

            return order;
        }
    }
}
