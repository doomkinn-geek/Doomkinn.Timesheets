using System.Collections.Generic;

namespace Doomkinn.Timesheets.Data.Interfaces
{
    public interface IEntitiesRepository<TEntity>
    {
        bool Add(TEntity entity);
        IEnumerable<TEntity> Get();
        bool Update(TEntity entity);
        bool Delete(int id);
    }

}
