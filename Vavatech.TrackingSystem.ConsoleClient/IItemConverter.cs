using System;
using System.Collections.Generic;
using System.Text;
using Vavatech.TrackingSystem.Models;

namespace Vavatech.TrackingSystem.ConsoleClient
{
    interface IItemConverter
    {
        Item Convert(string[] columns);
    }

    class ProductConverter : IItemConverter
    {
        public Item Convert(string[] columns)
        {
            int id = int.Parse(columns[1]);
            string name = columns[2];
            string serialNumber = columns[3];

            return new Product(id, name, serialNumber, null);
        }
    }

    class ServiceConverter : IItemConverter
    {
        public Item Convert(string[] columns)
        {
            int id = int.Parse(columns[1]);
            string name = columns[2];
            decimal unitPrice = decimal.Parse( columns[3]);

            return new Service(id, name, unitPrice);
        }
    }


    class ItemFactory
    {
        public static IItemConverter GetConverter(string itemType)
        {
            switch (itemType)
            {
                case "Product": return new ProductConverter();
                case "Service": return new ServiceConverter();
                default: throw new NotSupportedException();
            }
        }
    }
}
