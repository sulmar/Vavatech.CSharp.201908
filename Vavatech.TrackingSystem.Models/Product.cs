using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vavatech.TrackingSystem.Models
{
    

    public class Service : Item
    {
        public Service(int id, string name, decimal unitPrice)
            : base(id, name)
        {
            UnitPrice = unitPrice;
        }
        public decimal UnitPrice { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"Cena: {UnitPrice}";
        }

        public override decimal Calculate()
        {
            return UnitPrice;
        }
        
    }

    public class Product : Item
    {
        public string SerialNumber { get; set; }
        public string Color { get; set; }

        public List<Part> Parts { get; set; }

        public Product(int id, string name, string serialNumber, List<Part> parts, string color = "White")
            : base(id, name)
        {
            this.SerialNumber = serialNumber;
            this.Color = color;
            this.Parts = parts;
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

            stringBuilder.Append(base.ToString());
            stringBuilder.AppendLine($"Kolor: {this.Color} S/N: {this.SerialNumber}");

            foreach (Part part in Parts)
            {
                stringBuilder.AppendLine(part.ToString());
            }

            return stringBuilder.ToString();
        }


        public override decimal Calculate()
        {
            //decimal totalUnitPrice = 0;

            //foreach (Part part in Parts)
            //{
            //    totalUnitPrice = totalUnitPrice + part.UnitPrice;
            //}

            //return totalUnitPrice;

            return Parts.Sum(part => part.UnitPrice);
        }
    }
}
