using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Commerce.Core.Domain;
using Commerce.Core.Specification;

namespace Commerce.Core.Repository
{
    public interface IRepository<TEntity> where TEntity : EntityBase, IAggregateRoot
    {
        TEntity FindById(Guid id);
        Task<TEntity> FindOneAsync(ISpecification<TEntity> spec);
        Task<List<TEntity>> FindAsync(ISpecification<TEntity> spec);
        Task<TEntity> AddAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
    }

    public interface IGridRepository<TEntity> where TEntity : EntityBase, IAggregateRoot
    {
        ValueTask<long> CountAsync(IGridSpecification<TEntity> spec);
        Task<List<TEntity>> FindAsync(IGridSpecification<TEntity> spec);
    }
}
