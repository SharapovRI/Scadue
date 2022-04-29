using Microsoft.EntityFrameworkCore;
using Scadue.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Scadue.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly DbSet<TEntity> _set;
        protected readonly NpgsqlContext _context;
        protected abstract IQueryable<TEntity> SetWithIncludes { get; }

        protected BaseRepository(NpgsqlContext npgsqlContext)
        {
            _context = npgsqlContext;
            _set = _context.Set<TEntity>();
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            var createdEntity = _set.Add(entity);

            await _context.SaveChangesAsync();

            return createdEntity.Entity;
        }

        public async Task<TEntity> DeleteAsync(int id)
        {
            var entity = await _set.FindAsync(id);

            _set.Remove(entity);

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> GetAsync(int id)
        {
            var entity = await SetWithIncludes.FirstOrDefaultAsync(p => p.Id == id);

            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var updatedEntity = _set.Update(entity);

            await _context.SaveChangesAsync();

            return updatedEntity.Entity;
        }

        public async Task<TEntity> UpdateReturnIncludesAsync(TEntity entity)
        {
            var updatedEntity = _set.Update(entity);

            await _context.SaveChangesAsync();

            var entityWithIncludes = await SetWithIncludes.FirstOrDefaultAsync(p => p.Id == updatedEntity.Entity.Id);

            return entityWithIncludes;
        }

        public async Task<IList<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> parameters)
        {
            return await SetWithIncludes.Where(parameters).ToListAsync();
        }       
    }
}
