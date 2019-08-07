using Microsoft.Win32.SafeHandles;
using System;
using System.Text;

namespace Vavatech.TrackingSystem.Models
{

    public class Order : BaseEntity
    {
        public DateTime CreatedOn { get; set; }
        // public Nullable<DateTime> FinishedDate { get; set; }
        public DateTime? FinishedDate { get; set; }

        public TimeSpan? Period
        {
            get
            {
                if (FinishedDate.HasValue)
                    return FinishedDate.Value.Subtract(CreatedOn);
                else
                    return null;
            }
        }

        public OrderStatus Status { get; set; }

        private bool isDone;

        // Property
        public bool IsDone
        {
            get
            {
                return isDone;
            }

            set
            {
                if (!IsDone)
                    isDone = value;
            }
        }

        //public bool GetDone()
        //{
        //    return isDone;
        //}

        //public void SetDone()
        //{
        //    isDone = true;
        //}


        public Item Item { get; set; }
        public short Quantity { get; set; }
        public decimal HourlyRate { get; set; }
        public Customer Customer { get; set; }

        // przeciążanie konstruktorów

        //public Order(Product product)
        //{
        //    this.CreatedOn = DateTime.Now;
        //    this.Quantity = 1;

        //    this.Product = product;
        //}

        //public Order(Product product, short quantity)
        //    : this(product)
        //{
        //    this.Quantity = quantity;
        //}


        // parametry opcjonalne
        public Order(Item item, Customer customer, short quantity = 1)
        {
            this.CreatedOn = DateTime.Now;
            this.Item = item;
            this.Quantity = quantity;
            this.Status = OrderStatus.Created;
            this.Customer = customer;
        }



        //public void Print()
        //{
        //    Console.WriteLine($"Zamówienie {Id}");
        //    Console.WriteLine($"Data zam. {CreatedOn}");

        //    if (FinishedDate.HasValue)
        //    {
        //        Console.WriteLine($"Data zak. {FinishedDate}");
        //    }

        //    // Console.WriteLine($"Produkt {Product.Name} {Product.Color}");
        //    Console.WriteLine(Product);

        //    Console.WriteLine($"Ilość {Quantity}");

         
        //}

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Zamówienie {Id}");
            stringBuilder.AppendLine($"Klient: {Customer}");
            stringBuilder.AppendLine($"Data zam. {CreatedOn}");

            if (FinishedDate.HasValue)
            {
                stringBuilder.AppendLine($"Data zak. {FinishedDate}");
            }

            // Console.WriteLine($"Produkt {Product.Name} {Product.Color}");
            stringBuilder.AppendLine(Item.ToString());

            stringBuilder.AppendLine($"Ilość {Quantity}");

            return stringBuilder.ToString();
        }


    }

    public enum OrderStatus 
    {
        Created,
        InProduction,
        Done,
        Canceled
    }

}
