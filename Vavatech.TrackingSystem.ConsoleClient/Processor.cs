using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
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

        public void Make(Product product, Process process)
        {
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

        public decimal CalculateStandardCost(TimeSpan time)
        {
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
