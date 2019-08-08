using System;
using System.Collections.Generic;
using System.Text;

namespace Vavatech.TrackingSystem.Models.SearchCriterias
{
    public abstract class SearchCriteria : Base
    {

    }

    public class CustomerSearchCriteria : SearchCriteria
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? IsRemoved { get; set; }
    }

    public class OrderSearchCriteria : SearchCriteria
    {
        public RangeDateTime Period { get; set; }
        public string Number { get; set; }
    }

    public class Range<T>
        where T : struct
    {
        public T? From { get; set; }
        public T? To { get; set; }
    }

    public class RangeDateTime : Range<DateTime>
    {
    }

    public class RangeTimeSpan : Range<TimeSpan>
    {
    }
}
