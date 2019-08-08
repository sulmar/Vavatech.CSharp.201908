using System.Collections.Generic;
using System.Text;
using Vavatech.TrackingSystem.Models;
using Vavatech.TrackingSystem.Models.SearchCriterias;

namespace Vavatech.TrackingSystem.IRepositories
{
    public interface ICustomerRepository : IEntityRepository<Customer>
    {
        List<Customer> Get(string city);
        List<Customer> Get(CustomerSearchCriteria criteria);
    }



}
