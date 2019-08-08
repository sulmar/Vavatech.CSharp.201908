using Bogus;
using System;
using System.Collections.Generic;
using System.Text;
using Vavatech.TrackingSystem.Models;

namespace Vavatech.TrackingSystem.ConsoleClient.Fakers
{
    class AddressFaker : Faker<Address>
    {
        public AddressFaker()
        {
            RuleFor(p => p.City, f => f.Address.City());
            RuleFor(p => p.Street, f => f.Address.StreetName());
            RuleFor(p => p.PostCode, f => f.Address.ZipCode());
        }
    }
}
