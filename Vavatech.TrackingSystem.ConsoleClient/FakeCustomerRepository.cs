using System;
using System.Collections.Generic;
using Vavatech.TrackingSystem.ConsoleClient.Fakers;
using Vavatech.TrackingSystem.Models;

namespace Vavatech.TrackingSystem.ConsoleClient
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> customers;

        // snippet: ctor
        public FakeCustomerRepository()
        {
            CustomerFaker customerFaker = new CustomerFaker();

            customers = customerFaker.Generate(1000);

            //customers = new List<Customer>()
            //{
            //    new Customer (1, "John", "Smith"),
            //    new Customer (2, "Ann", "Smith"),
            //    new Customer (3, "Peter", "Novak"),
            //};
        }

        public void Add(Customer customer)
        {
            customers.Add(customer);
        }

        public List<Customer> Get()
        {
            return customers;
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> Get(string city)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
