using System;
using System.Diagnostics;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Commerce.Infrastructure.Validator
{
    [DebuggerStepThrough]
    public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull, IRequest<TResponse>
        where TResponse : notnull
    {
        private readonly IValidator<TRequest> _validator;
        private readonly ILogger<RequestValidationBehavior<TRequest, TResponse>> _logger;

        public RequestValidationBehavior(IValidator<TRequest> validator,
            ILogger<RequestValidationBehavior<TRequest, TResponse>> logger)
        {
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<TResponse> Handle(TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            _logger.LogInformation(
                "[{Prefix}] Handle request={X-RequestData} and response={X-ResponseData}",
                nameof(RequestValidationBehavior<TRequest, TResponse>), typeof(TRequest).Name, typeof(TResponse).Name);

            _logger.LogDebug($"Handling {typeof(TRequest).FullName} with content {JsonSerializer.Serialize(request)}");

            await _validator.HandleValidation(request);

            var response = await next();

            _logger.LogInformation($"Handled {typeof(TRequest).FullName}");
            return response;
        }
    }
}
