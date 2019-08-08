using System.Collections.Generic;

namespace Vavatech.TrackingSystem.IRepositories
{
    // Interfejs generyczny
    public interface IEntityRepository<TEntity>
    {
        List<TEntity> Get();
        TEntity Get(int id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(int id);
    }



}
