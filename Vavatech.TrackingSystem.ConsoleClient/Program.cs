using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;
using Vavatech.TrackingSystem.ConsoleClient.Helpers;
using Vavatech.TrackingSystem.FakeRepositories;
using Vavatech.TrackingSystem.FileRepositories;
using Vavatech.TrackingSystem.IRepositories;
using Vavatech.TrackingSystem.Models;
using Vavatech.TrackingSystem.Models.Exceptions;

namespace Vavatech.TrackingSystem.ConsoleClient
{
    partial class Program
    {
        // workaround < C# 7.2
       // static void Main(string[] args) => MainAsync(args).GetAwaiter().GetResult();

        // Project -> Properties -> Build -> Advanced -> C# latest minor version (latest)
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello in Tracking System!");

            FlagTest();

         //   ProcessorTest();

            //  SyncTest();

            // TryCatchTest();

           // await AsyncAwaitTestAsync();

            // TaskResultTest();

            // TaskTest();

            // ThreadTest();

            // QueueTest();

            // ExtensionMethodsTest();

            // GroupByCountTest();

            // GroupByTest();

            // CreateOrderTest();

            // RepositoryTest();

            // ProcessorTest();

            //  LinqTest();


            //  VarTest();

            //  DynamicTest();


            //   Console.WriteLine($"Przyjęto zamówienie na {order.Product.Name} w ilości: {order.Quantity}");


            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static void FlagTest()
        {
            Vehicle vehicle = new Vehicle();

        }

        private static void MultipleParametersTest()
        {
            MultipleParameters(message: "Hello", lat: 50, lng: 20);

            MultipleParameters(lat: 10, lng: 20, message: "Hello");


            Draw(20, 10);

            Draw(lat: 20, lng: 10);
        }
        private static void MultipleParameters(int lat, int lng, int alt = 0, string message = "", float weight = 1)
        {

        }

        private static void Draw(int lng, int lat)
        {

        }

        private static void TryCatchTest()
        {
            string path = @"c:\temp\test\blabla.txt";

            try
            {
                File.Open(path, System.IO.FileMode.Open);
                Console.WriteLine("Next job");
            }

            catch (DirectoryNotFoundException e)
            {
                Directory.CreateDirectory(@"c:\temp\test");
            }
            catch(FileNotFoundException e)
            {
                File.Create(path);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }
       
        private static void TaskResultTest()
        {
            Processor processor = new Processor();
            processor.Log += LogThread;

            //Task<decimal> taskCost = Task.Run(()=>processor.CalculateStandardCost(TimeSpan.FromSeconds(5)));
            //taskCost.ContinueWith(t => Send($"Koszt: {t.Result}"));

            processor.CalculateStandardCostAsync(TimeSpan.FromSeconds(5))
                    .ContinueWith(t => SendAsync($"Koszt: {t.Result:C2}"));

            // Send($"Koszt: {taskCost.Result}");

            Console.WriteLine("next job");
        }

        private static void SyncTest()
        {
            Processor processor = new Processor();
            processor.Log += LogThread;

            decimal cost = processor.CalculateStandardCost(TimeSpan.FromSeconds(5));
            Send($"Koszt: {cost}");

            Console.WriteLine("next job");
        }

        private static async Task AsyncAwaitTestAsync()
        {
            Processor processor = new Processor();
            processor.Log += LogThread;

            decimal cost = await processor.CalculateStandardCostAsync(TimeSpan.FromSeconds(5));
            await SendAsync($"Koszt: {cost:C2}");

            Console.WriteLine("next job");
        }

        
        private static Task SendAsync(string message)
        {
            return Task.Run(() => Send(message));
        }
        private static void Send(string message)
        {
            LogThread($"Sending... {message}");
            Thread.Sleep(TimeSpan.FromSeconds(5));
            LogThread("Sent.");
        }

        private static void TaskTest()
        {
            LogThread("Start");

            Order order = CreateOrderTest();

            var product = order.Item as Product;

            if (product != null)
            {
                Operation operation = new AssemblyOperation();

                operation.Log += LogThread;

                //Task task = new Task(() => operation.Execute(product));
                //task.Start();

                for (int i = 0; i < 100; i++)
                {
                    Task task = Task.Run(() => operation.Execute(product));
                }
            }
        }

       

        private static void ThreadTest()
        {

            LogThread("Start");

            Order order = CreateOrderTest();

            var product = order.Item as Product;

            if (product != null)
            {
                Operation operation = new AssemblyOperation();

                operation.Log += LogThread;

                // synchroniczne
                // operation.Execute(product)

                // asynchroniczne
                //Thread thread1 = new Thread(() => operation.Execute(product));

                //Thread thread2 = new Thread(() => operation.Execute(product));

                //Thread thread3 = new Thread(() => operation.Execute(product));

                //thread1.Start();

                //thread2.Start();

                //thread3.Start();

                // Utworzenie wątków
                //for (int i = 0; i < 100; i++)
                //{
                //    Thread thread = new Thread(() => operation.Execute(product));
                //    thread.Start();
                //}

                // Pula wątków

                for (int i = 0; i < 100; i++)
                {
                    //ThreadPool.QueueUserWorkItem(Download, "http://www.vavatech.pl");
                    ThreadPool.QueueUserWorkItem(state => operation.Execute(product));
                }
               
            }
        }
       
        private static void Download(object arg)
        {
            string url = (string)arg;

            Download(url);
        }

        private static void Download(string url)
        {

            LogThread("Downloading...");
            Thread.Sleep(TimeSpan.FromSeconds(3));
            LogThread("Downloaded.");
        }

        private static void LogThread(string message)
        {
            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} {message}");
        }

        private static void QueueTest()
        {
            Processor processor = new Processor();
            processor.Build();
            processor.Build2();
        }

        private static void ExtensionMethodsTest()
        {
            Order order = CreateOrderTest();

            if (order.CreatedOn.DayOfWeek == DayOfWeek.Saturday ||
                order.CreatedOn.DayOfWeek == DayOfWeek.Sunday)
            {

            }

            if (DateTimeHelper.IsHoliday(order.CreatedOn))
            {

            }

            if (order.CreatedOn.IsHoliday())
            {

            }



            DateTime dueDate = order.CreatedOn.AddWorkDays(5);
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

        private static void GroupByTest()
        {
            ICustomerRepository customerRepository = new FakeCustomerRepository();

            List<Customer> customers = customerRepository.Get();

            var groups = customers
                .GroupBy(c => c.IsRemoved)
                .ToList();

            foreach (var group in groups)
            {
                Console.WriteLine("======================");
                Console.WriteLine($"Grupa: {group.Key}");

                foreach (var customer in group)
                {
                    Console.WriteLine(customer.FirstName);
                }
            }


        }

        private static void GroupByCountTest()
        {
            ICustomerRepository customerRepository = new FakeCustomerRepository();

            List<Customer> customers = customerRepository.Get();

            var groups = customers
                .GroupBy(c => c.IsRemoved)
                .Select(g => new { IsRemoved = g.Key, Quantity = g.Count() })
                .ToList();


            foreach (var group in groups)
            {
                Console.WriteLine($"Grupa {group.IsRemoved} ilość: {group.Quantity}");
            }


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

            if (order.Quantity < 1)
            {
                throw new ArgumentOutOfRangeException("Quantity");
            }

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

                try
                {

                    for (int i = 0; i < order.Quantity; i++)
                    {
                        processor.Make(product, process);
                    }

                    order.Status = OrderStatus.Done;
                    order.FinishedDate = DateTime.Now;

                    Console.WriteLine($"Czas realizacji: {order.Period}");
                }
                catch(OperationException e)
                {
                    order.Status = OrderStatus.Canceled;
                    Console.WriteLine($"{e.Message} id operacji: {e.Operation.Id}");
                }

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

            //Console.WriteLine(item.Calculate());

            //Console.WriteLine(item.ToString());

            Customer customer = new Customer(1, "Marcin", "Sulecki")
            {
                HomeAddress = new Address("Warszawa", "Powst. Śląskich", "01466"),
                WorkAddress = new Address("Warszawa", "Olesińska", "01100")
            };

            Order order = new Order(item, customer, 2)
            {
                Id = 1,
            };

            order.Status = OrderStatus.Created;

            //Console.WriteLine(order);

            return order;
        }
    }
}
