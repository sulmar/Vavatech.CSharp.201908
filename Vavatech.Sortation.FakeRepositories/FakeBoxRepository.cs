using System;
using System.Collections.Generic;
using Vavatech.Sortation.FakeRepositories.Fakers;
using Vavatech.Sortation.IRepositories;
using Vavatech.Sortation.Models;

namespace Vavatech.Sortation.FakeRepositories
{
    public class FakeBoxRepository : IBoxRepository
    {
        private readonly List<Box> boxes;

        public FakeBoxRepository(BoxFaker boxFaker)
        {
            boxes = boxFaker.Generate(20);
        }

        public List<Box> Get() => boxes;
    }
}
