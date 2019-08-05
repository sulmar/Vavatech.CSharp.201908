using System;
using System.Collections.Generic;
using System.Text;

namespace Vavatech.TrackingSystem.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public string Color { get; set; }

        public Product(int id, string name, string serialNumber, string color = "White")
        {
            this.Id = id;
            this.Name = name;
            this.SerialNumber = serialNumber;
            this.Color = color;
        }
    }
}
