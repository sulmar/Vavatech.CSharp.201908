﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Vavatech.TrackingSystem.Models
{

    public class Address : Base
    {
        public Address(string city, string street, string postCode)
        {
            City = city;
            Street = street;
            PostCode = postCode;
        }

        public string City { get; set; }
        public string Street { get; set; }
        public string PostCode { get; set; }

        public override string ToString()
        {
            return $"{Street} {PostCode} {City}";
        }
    }
    public class Customer : BaseEntity
    {
        public Customer(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Address HomeAddress { get; set; }
        public Address WorkAddress { get; set; }
        public Address InvoiceAddress { get; set; }


        public bool HasHomeAddress
        {
            get
            {
                return HomeAddress != null;
            }
        }

        public bool HasWorkAddress
        {
            get
            {
                return WorkAddress != null;
            }
        }

        public bool HasInvoiceAddress
        {
            get
            {
                return InvoiceAddress != null;
            }
        }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }


        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(FullName);
            AppendMyLine(stringBuilder);

            if (HasHomeAddress)
            {
                stringBuilder.AppendLine("Adres domowy:");
                stringBuilder.AppendLine(HomeAddress.ToString());
                AppendMyLine(stringBuilder);
            }

            if (HasInvoiceAddress)
            {
                stringBuilder.AppendLine("Adres fakturowania:");
                stringBuilder.AppendLine(InvoiceAddress.ToString());
                AppendMyLine(stringBuilder);
            }

            return stringBuilder.ToString();
        }

        private static void AppendMyLine(StringBuilder stringBuilder)
        {
            stringBuilder.AppendLine("---------------------");
        }
    }
}