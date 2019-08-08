using System.Collections.Generic;
using System.Text;
using Vavatech.TrackingSystem.Models;

namespace Vavatech.TrackingSystem.IRepositories
{
    public interface ICustomerRepository : IEntityRepository<Customer>
    {
        List<Customer> Get(string city);
    }



}
