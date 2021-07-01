using Commerce.Core.Domain;
using Commerce.Infrastructure.EfCore;

namespace ProductService.Infrastructure.Data
{
    public class Repository<TEntity> : RepositoryBase<MainDbContext, TEntity> where TEntity : EntityBase, IAggregateRoot
    {
        public Repository(MainDbContext dbContext) : base(dbContext)
        {
        }
    }
}
