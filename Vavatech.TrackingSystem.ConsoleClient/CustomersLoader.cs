using System.Collections.Generic;
using System.IO;
using Vavatech.TrackingSystem.Models;

namespace Vavatech.TrackingSystem.ConsoleClient
{
  
    internal class CustomersLoader
    {
        public List<Customer> Load(string filename)
        {
            string[] lines = File.ReadAllLines(filename);

            List<Customer> customers = new List<Customer>();

            foreach (string line in lines)
            {
                string[] columns = line.Split(',');
                Customer customer = Convert(columns);

                customers.Add(customer);
            }

            return customers;
        }

        private static Customer Convert(string[] columns)
        {
            int id = int.Parse(columns[0]);
            string firstName = columns[1];
            string lastName = columns[2];

            Customer customer = new Customer(id, firstName, lastName);
            return customer;
        }
    }

}
