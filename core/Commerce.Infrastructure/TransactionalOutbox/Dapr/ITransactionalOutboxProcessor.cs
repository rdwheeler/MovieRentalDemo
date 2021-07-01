using System;
using System.Threading;
using System.Threading.Tasks;

namespace Commerce.Infrastructure.TransactionalOutbox.Dapr
{
    public interface ITransactionalOutboxProcessor
    {
        Task HandleAsync(Type integrationAssemblyType, CancellationToken cancellationToken = new());
    }
}
