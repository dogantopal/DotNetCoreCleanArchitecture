using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Contracts
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetAsync(int id);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<List<TEntity>> GetAll();
        Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
