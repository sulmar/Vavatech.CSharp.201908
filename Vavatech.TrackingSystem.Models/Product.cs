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

        public List<Part> Parts { get; set; }

        public Product(int id, string name, string serialNumber, string color = "White")
        {
            this.Id = id;
            this.Name = name;
            this.SerialNumber = serialNumber;
            this.Color = color;

            this.Parts = new List<Part>();
        }

        //public void Print()
        //{
        //    Console.WriteLine($"Produkt {this.Name} {this.Color} {this.SerialNumber}");

        //    PrintParts();
        //}

        //private void PrintParts()
        //{
        //    foreach (Part part in Parts)
        //    {
        //        Console.WriteLine(part.ToString());
        //    }
        //}

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Produkt {this.Name} {this.Color} {this.SerialNumber}");

            foreach (Part part in Parts)
            {
                stringBuilder.AppendLine(part.ToString());
            }

            return stringBuilder.ToString();
        }
    }
}
