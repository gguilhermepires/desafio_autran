using Guilherme.Data.Context;
using Guilherme.Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Guilherme.Data.Repository.Base
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DataContext _dbContext;
        protected DbSet<TEntity> _dbSet;

        protected Repository(DataContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        public async Task AddAsync(TEntity obj)
        {
            await _dbSet.AddAsync(obj);
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> UpdateAsync(TEntity obj)
        {
            return await Task.Run(() =>
            {
                var updated = _dbSet.Update(obj);
                updated.State = EntityState.Modified;
                return updated.Entity;
            });
        }

        public async Task DeleteAsync(Guid id)
        {
            _dbSet.Remove(await _dbSet.FindAsync(id));
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}