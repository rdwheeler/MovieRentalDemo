using Commerce.Core.Domain;
using Commerce.Infrastructure.EfCore;

namespace SettingService.Infrastructure.Data
{
    public class Repository<TEntity> : RepositoryBase<MainDbContext, TEntity> where TEntity : EntityBase, IAggregateRoot
    {
        public Repository(MainDbContext dbContext) : base(dbContext)
        {
        }
    }
}
