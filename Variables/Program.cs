using System;

namespace Variables
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine("Podaj kod kreskowy");

            string barcode = Console.ReadLine();

            Console.WriteLine("Podaj ilość");

            int quantity = int.Parse(Console.ReadLine());

            // zla praktyka
            // Console.WriteLine("Wprowadzono kod: " + barcode + " ilość: " + quantity);

            // Console.WriteLine(string.Format("Przyjęto na produkcję kod: {0} ilość: {1}", barcode, quantity));


            DateTime productionDate = DateTime.Now;

            Console.WriteLine($"Przyjęto na produkcję kod: {barcode} ilość: {quantity} data: {productionDate}");

            char sign = 'a';

            char firstLetter = barcode[0];

          

        }
    }
}
