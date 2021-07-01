using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Commerce.Infrastructure.Controller;
using Commerce.Infrastructure.TransactionalOutbox.Dapr;

namespace RentalService.Application.V1
{
    [ApiVersionNeutral]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class TransactionalOutboxProcessor : BaseController
    {
        private readonly ITransactionalOutboxProcessor _outboxProcessor;

        public TransactionalOutboxProcessor(ITransactionalOutboxProcessor outboxProcessor)
        {
            _outboxProcessor = outboxProcessor ?? throw new ArgumentNullException(nameof(outboxProcessor));
        }

        [HttpPost("RentalOutboxCron")]
        public async Task<ActionResult> HandleRentalOutboxCronAsync(CancellationToken cancellationToken = new())
        {
            await _outboxProcessor.HandleAsync(typeof(Store.IntegrationEvents.Anchor), cancellationToken);

            return Ok();
        }
    }
}
