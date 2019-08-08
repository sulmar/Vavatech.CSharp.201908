using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using Vavatech.TrackingSystem.ConsoleClient.Fakers;
using Vavatech.TrackingSystem.Models;
using System.Linq;
using Vavatech.TrackingSystem.IRepositories;

namespace Vavatech.TrackingSystem.ConsoleClient
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> customers;

        // snippet: ctor
        public FakeCustomerRepository()
        {
            CustomerFaker customerFaker = new CustomerFaker(new AddressFaker());

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

        //public Customer Get(int id)
        //{
        //    Customer result = null;

        //    foreach (Customer customer in customers)
        //    {
        //        if (customer.Id == id)
        //        {
        //            result = customer;
        //            break;
        //        }
        //    }

        //    return result;

        //}

        public Customer Get(int id) => customers.FirstOrDefault(c => c.Id == id);

        //public List<Customer> Get(string city)
        //{
        //    List<Customer> results = new List<Customer>();

        //    foreach (Customer customer in customers)
        //    {
        //        if (customer.HomeAddress.City.StartsWith(city))
        //        {
        //            results.Add(customer);
        //        }
        //    }

        //    return results;
        //}

        public List<Customer> Get(string city) => customers
                    .Where(c => c.HomeAddress.City.StartsWith(city))
                    .OrderBy(c => c.LastName)
                    .ToList();
        


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
