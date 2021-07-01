using Microsoft.AspNetCore.Authorization;

namespace Commerce.Infrastructure.Auth
{
    public interface IAuthRequest : IAuthorizationRequirement
    {
    }
}
