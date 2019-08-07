using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Vavatech.TrackingSystem.Models
{
    public abstract class Operation : BaseEntity
    {
        public string Name { get; set; }
        public TimeSpan AvgTime { get; set; }
        public abstract void Execute(Product product);

        public delegate void LogDelegate(string message);

        public LogDelegate Log;

        //public void Log(string message)
        //{
        //    Console.WriteLine($"{DateTime.Now} > {message}");
        //}

        public delegate decimal CalculateDelegate(TimeSpan time);

        public CalculateDelegate Calculate;

        protected Operation(string name)
        {
            Name = name;
        }

        //public decimal Calculate(TimeSpan time)
        //{
        //    return (decimal) time.TotalSeconds * 100;
        //}


    }

    public class AssemblyOperation : Operation
    {
        public AssemblyOperation() : base("Składanie")
        {
        }

        public override void Execute(Product product)
        {
            Random random = new Random();

            //if (Log!=null)
            //  Log($"Składanie {product.Name}...");

            Log?.Invoke($"Składanie {product.Name}...");

            TimeSpan operationTime = TimeSpan.FromSeconds(random.Next(10));

            Thread.Sleep(operationTime);

            Log?.Invoke("Złożono.");

            if (Calculate != null)
            {
                decimal cost = Calculate(operationTime);

                Log?.Invoke($"Koszt operacji {cost}");
            }

        }
    }

    public class BoxOperation : Operation
    {
        public BoxOperation() : base("Pakowanie")
        {
        }

        public override void Execute(Product product)
        {
            Log?.Invoke($"Pakowanie {product.Name}...");
            Thread.Sleep(TimeSpan.FromSeconds(5));
            Log?.Invoke("Spakowano");
        }
    }

    public class TestOperation : Operation
    {
        public TestOperation() : base("Testowanie")
        {
        }

        public override void Execute(Product product)
        {
            Log?.Invoke($"Testowanie {product.Name}...");
            Thread.Sleep(TimeSpan.FromSeconds(10));
            Log?.Invoke("Przetestowano.");
        }
    }

    public class MarkOperation : Operation
    {
        public MarkOperation() : base("Znakowanie")
        {
        }

        public override void Execute(Product product)
        {
            Log?.Invoke($"Znakowanie {product.Name}...");
            Thread.Sleep(TimeSpan.FromSeconds(1));
            Log?.Invoke("Oznakowano.");
        }
    }

    public class Process
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public Product Product { get; set; }
        public List<Operation> Operations { get; set; }

        
    }
}
