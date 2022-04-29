using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Scadue.Data.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class, IEntity
    {
        Task<TEntity> CreateAsync(TEntity entity);

        Task<TEntity> GetAsync(int id);

        Task<IList<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> parameters);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<TEntity> UpdateReturnIncludesAsync(TEntity entity);

        Task<TEntity> DeleteAsync(int id);
    }
}
