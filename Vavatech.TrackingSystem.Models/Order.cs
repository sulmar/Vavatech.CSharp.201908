using System;

namespace Vavatech.TrackingSystem.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        // public Nullable<DateTime> FinishedDate { get; set; }
        public DateTime? FinishedDate { get; set; }

        public TimeSpan? Period
        {
            get
            {
                if (FinishedDate.HasValue)
                    return CreatedOn.Subtract(FinishedDate.Value);
                else
                    return null;
            }
        }

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


        public Product Product { get; set; }
        public short Quantity { get; set; }
        public decimal HourlyRate { get; set; }

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
        public Order(Product product, short quantity = 1)
        {
            this.CreatedOn = DateTime.Now;
            this.Product = product;
            this.Quantity = quantity;
        }



        public void Print()
        {
            Console.WriteLine($"Zamówienie {Id}");
            Console.WriteLine($"Data zam. {CreatedOn}");

            if (FinishedDate.HasValue)
            {
                Console.WriteLine($"Data zak. {FinishedDate}");
            }

            // Console.WriteLine($"Produkt {Product.Name} {Product.Color}");
            Console.WriteLine(Product);

            Console.WriteLine($"Ilość {Quantity}");

         
        }

     
    }
}
