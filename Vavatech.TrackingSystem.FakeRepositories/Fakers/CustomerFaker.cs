using Bogus;
using System;
using System.Collections.Generic;
using System.Text;
using Vavatech.TrackingSystem.Models;

namespace Vavatech.TrackingSystem.ConsoleClient.Fakers
{
    class CustomerFaker : Faker<Customer>
    {
        public CustomerFaker(AddressFaker addressFaker)
        {
            RuleFor(p => p.Id, f => f.IndexFaker);
            RuleFor(p => p.FirstName, f => f.Person.FirstName);
            RuleFor(p => p.LastName, f => f.Person.LastName);
            RuleFor(p => p.IsRemoved, f => f.Random.Bool(0.2f));

            RuleFor(p => p.HomeAddress, f => addressFaker.Generate());
            RuleFor(p => p.WorkAddress, f => addressFaker.Generate());
            RuleFor(p => p.InvoiceAddress, f => addressFaker.Generate());

        }
    }
}
