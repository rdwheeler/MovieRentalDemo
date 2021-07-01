using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Commerce.Infrastructure.EfCore
{
    public interface IDbFacadeResolver
    {
        DatabaseFacade Database { get; }
    }
}