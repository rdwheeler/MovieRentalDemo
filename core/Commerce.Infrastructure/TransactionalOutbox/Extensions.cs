using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Commerce.Core.Domain;
using Commerce.Infrastructure.TransactionalOutbox.Dapr;
using Commerce.Infrastructure.TransactionalOutbox.Dapr.Internal;

namespace Commerce.Infrastructure.TransactionalOutbox
{
    public static class Extensions
    {
        public static IServiceCollection AddTransactionalOutbox(this IServiceCollection services, IConfiguration config, string provider = "dapr")
        {
            switch (provider)
            {
                case "dapr":
                {
                    services.Configure<DaprTransactionalOutboxOptions>(config.GetSection(DaprTransactionalOutboxOptions.Name));
                    services.AddScoped<INotificationHandler<EventWrapper>, LocalDispatchedHandler>();
                    services.AddScoped<ITransactionalOutboxProcessor, TransactionalOutboxProcessor>();
                    break;
                }
            }

            return services;
        }
    }
}
