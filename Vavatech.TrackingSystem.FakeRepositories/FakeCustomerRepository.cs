using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using Vavatech.TrackingSystem.ConsoleClient.Fakers;
using Vavatech.TrackingSystem.Models;
using System.Linq;
using Vavatech.TrackingSystem.IRepositories;
using Vavatech.TrackingSystem.Models.SearchCriterias;
using System.Collections;
using Bogus;
using System.Transactions;

namespace Vavatech.TrackingSystem.FakeRepositories
{
    public class FakeProductRepository : FakeEntityRepository<Product>
    {
        public FakeProductRepository(Faker<Product> faker) : base(faker)
        {
        }

        public override void Remove(int id)
        {
            throw new NotSupportedException();
        }
    }

    public class FakeEntityRepository<TEntity> : IEntityRepository<TEntity>
        where TEntity : BaseEntity
    {

        protected List<TEntity> entities;

        public FakeEntityRepository(Faker<TEntity> faker)
        {
            entities = faker.Generate(100);
        }
        public virtual void Add(TEntity entity) => entities.Add(entity);

        public virtual List<TEntity> Get() => entities;

        public virtual TEntity Get(int id) => entities.FirstOrDefault(e => e.Id == id);

        public virtual void Remove(int id) => entities.Remove(Get(id));

        public virtual void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

       
    }

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
                    .ThenBy(c => c.FirstName)
                    .ToList();

        public List<Customer> Get(CustomerSearchCriteria criteria)
        {
            IEnumerable<Customer> results = customers;

            if (!string.IsNullOrEmpty(criteria.City))
            {
                results = results.Where(c => c.HomeAddress.City == criteria.City);
            }

            if (!string.IsNullOrEmpty(criteria.FirstName))
            {
                results = results.Where(c => c.FirstName.StartsWith(criteria.FirstName));
            }

            if (!string.IsNullOrEmpty(criteria.LastName))
            {
                results = results.Where(c => c.LastName.StartsWith(criteria.LastName));
            }

            if (criteria.IsRemoved.HasValue)
            {
                results = results.Where(c => c.IsRemoved == criteria.IsRemoved);
            }

            return results.ToList();
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
