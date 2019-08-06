using System.Collections.Generic;
using System.Text;
using Vavatech.TrackingSystem.Models;

namespace Vavatech.TrackingSystem.ConsoleClient
{
    interface ICustomerRepository : IEntityRepository<Customer>
    {
        List<Customer> Get(string city);
    }


    // Interfejs generyczny
    interface IEntityRepository<TEntity>
    {
        List<TEntity> Get();
        TEntity Get(int id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(int id);
    }

    interface IItemRepository : IEntityRepository<Item>
    {

    }

    interface IOrderRepository : IEntityRepository<Order>
    {

    }



}
