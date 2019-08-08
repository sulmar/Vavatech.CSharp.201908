using System;
using System.Collections.Generic;
using System.Linq;
using Vavatech.Sortation.FakeRepositories;
using Vavatech.Sortation.FakeRepositories.Fakers;
using Vavatech.Sortation.IRepositories;
using Vavatech.Sortation.Models;

namespace Vavatech.Sortation.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Sortation!");

            // TODO: Pobierz listę paczek

            GetBoxesTest();

        }

        private static void GetBoxesTest()
        {
            IBoxRepository boxRepository = new FakeBoxRepository(new BoxFaker(new DimensionFaker()));

            var boxes = boxRepository.Get();

            foreach (var box in boxes)
            {
                Console.WriteLine(box);
            }

            List<SortSchema> sortSchemas = new List<SortSchema>
            {
                new SortSchema(new Chute("Zrzutnia A"), new Route('1', "Poznań")),
                new SortSchema(new Chute("Zrzutnia A"), new Route('2', "Warszawa")),
                new SortSchema(new Chute("Zrzutnia B"), new Route('3', "Warszawa")),
                new SortSchema(new Chute("Zrzutnia A"), new Route('4', "Warszawa")),
                new SortSchema(new Chute("Zrzutnia B"), new Route('5', "Warszawa")),
                new SortSchema(new Chute("Zrzutnia C"), new Route('6', "Poznań")),
                new SortSchema(new Chute("Zrzutnia C"), new Route('7', "Warszawa")),
                new SortSchema(new Chute("Zrzutnia C"), new Route('8', "Warszawa")),
                new SortSchema(new Chute("Zrzutnia C"), new Route('9', "Warszawa")),
                new SortSchema(new Chute("Zrzutnia C"), new Route('0', "Bydgoszcz")),

            };

            var cities = sortSchemas.Select(s => s.Route.Name);

            var mycities = new List<string> { "Warszawa", "Bydgoszcz", "Łódź" };

            var q = cities.Concat(mycities).Distinct();
            var q1 = mycities.Except(cities);
            var q2 = cities.Intersect(mycities);

            var results = q2.ToList();

            IPostalSorting postalSorting = new PostalSorting(sortSchemas);
            var chutes = postalSorting.Sort(boxes);


        }
    }
}
