using System;
using System.Collections.Generic;
using System.Text;

namespace Vavatech.TrackingSystem.Models
{
    public class Part : BaseEntity
    {
        public Part(int id, string description, decimal unitPrice)
        {
            Id = id;
            Description = description;
            UnitPrice = unitPrice;
        }

        public string Description { get; set; }
        public decimal UnitPrice { get; set; }

        //public void Print()
        //{
        //    Console.WriteLine($"{Description} {UnitPrice}");
        //}

        public override string ToString()
        {
            return $"{Description} {UnitPrice}";
        }

    }
}
