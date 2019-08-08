using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using Vavatech.Sortation.Models;

namespace Vavatech.Sortation.ConsoleClient
{
    public interface IPostalSorting
    {
        List<Chute> Sort(List<Box> boxes);
    }

    public class PostalSorting : IPostalSorting
    {
        private readonly List<SortSchema> sortSchemas;

        public PostalSorting(List<SortSchema> sortSchemas)
        {
            this.sortSchemas = sortSchemas;
        }
        
        public List<Chute> Sort(List<Box> boxes)
        {

            List<Chute> results = new List<Chute>();

            var q = from b in boxes
                    join s in sortSchemas
                    on b.Prefix equals s.Route.Prefix
                    select new { Box = b, s.Chute };

            var chutes = q.GroupBy(b => b.Chute)
                .Select(c => c.Key.Boxes = c.Select(c=>c.Box).ToList());


            throw new NotImplementedException();
        }
    }
}
