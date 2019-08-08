using Bogus;
using System;
using System.Collections.Generic;
using System.Text;
using Vavatech.Sortation.Models;

namespace Vavatech.Sortation.FakeRepositories.Fakers
{
    public class BoxFaker : Faker<Box>
    {
        public BoxFaker(DimensionFaker dimensionFaker)
        {
            StrictMode(true);
            RuleFor(p => p.Id, f => f.IndexFaker);
            RuleFor(p => p.BarCode, f => f.Commerce.Ean8());
            RuleFor(p => p.Dimension, f => dimensionFaker.Generate());
            RuleFor(p => p.Weight, f => f.Random.Float(1, 100));
            RuleFor(p => p.IsDamaged, f => f.Random.Bool(0.3f));
        }
    }

    public class DimensionFaker : Faker<Dimension>
    {
        public DimensionFaker()
        {
            StrictMode(true);
            RuleFor(p => p.Width, f => f.Random.Int(100, 200));
            RuleFor(p => p.Height, f => f.Random.Int(50, 100));
            RuleFor(p => p.Length, f => f.Random.Int(100, 500));
            CustomInstantiator(f => new Dimension(0, 0, 0));
        }



    }
}
