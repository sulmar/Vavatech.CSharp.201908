using Bogus.DataSets;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vavatech.TrackingSystem.Models;

namespace Vavatech.TrackingSystem.ConsoleClient
{

    class OperationEventArgs : EventArgs
    {
        public OperationEventArgs(DateTime beginDate)
        {
            BeginDate = beginDate;
        }

        public DateTime BeginDate { get; set; }
    }

    class Processor
    {
       

        public delegate void OperationBeginDelegate(object sender, OperationEventArgs e);
        public event OperationBeginDelegate OperationBegin;

        public delegate void OperationDoneDelegate(string name);
        public event OperationDoneDelegate OperationDone;

        public delegate void LogDelegate(string message);

        public LogDelegate Log;


        public void Build()
        {

            // process.Operations

            Queue<Operation> todo = new Queue<Operation>();

            todo.Enqueue(new AssemblyOperation());
            todo.Enqueue(new BoxOperation());
            todo.Enqueue(new MarkOperation());

            while(todo.Any())
            {

                Operation operation1 = todo.Peek();

                Operation operation = todo.Dequeue();

                Console.WriteLine(operation);
            }
          
        }

        public void Build2()
        {
            Stack<Operation> todo = new Stack<Operation>();

            todo.Push(new AssemblyOperation());
            todo.Push(new BoxOperation());
            todo.Push(new MarkOperation());

            while (todo.Any())
            {
                Operation operation = todo.Pop();

                Console.WriteLine(operation);
            }
        }

        /// <summary>
        /// Utwórz produkt na podstawie procesu
        /// </summary>
        /// <param name="product">Produkt</param>
        /// <param name="process">Proces produkcyjny</param>
        /// <exception cref="OperationException">Operation Exception</exception>
        /// 
        public void Make(Product product, Process process)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            if (process == null)
                throw new ArgumentNullException(nameof(process));

            if (!process.Operations.Any())
            {
                throw new InvalidOperationException("Brak operacji");
            }


            foreach (Operation operation in process.Operations)
            {
                operation.Log = LogConsole;

                operation.Log += LogColorConsole;

                // Metoda anonimowa
                operation.Log += delegate (string text)
                {
                    Console.WriteLine($">>> {text}");
                };

                operation.Log += msg => Console.WriteLine($"=> {msg}");

               // operation.Log -= LogColorConsole;
                // operation.Log = null;

                // operation.Log = Send;

                operation.Log += Console.WriteLine;

                operation.Calculate = CalculateStandardCost;

                OperationBegin?.Invoke(this, new OperationEventArgs(DateTime.Now));

                operation.Execute(product);

                OperationDone?.Invoke(operation.Name);
            }
        }

        public Task<decimal> CalculateStandardCostAsync(TimeSpan time)
        {
            return Task.Run(() => CalculateStandardCost(time));
        }

        public decimal CalculateStandardCost(TimeSpan time)
        {
            Log?.Invoke("Calculating...");
            Thread.Sleep(TimeSpan.FromSeconds(5));
            Log?.Invoke("Calculated.");

            return (decimal)time.TotalSeconds * 100;
        }

        public void LogConsole(string message)
        {
            Console.WriteLine($"{DateTime.Now} > {message}");
        }

        public void LogColorConsole(string message)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{DateTime.Now} > {message}");
            Console.ResetColor();
        }

        public void Send(string content, string from, string to)
        {

        }
    }
}
