using System;
using System.Threading;
using System.Threading.Tasks;
using Store.AppContracts.Dtos;
using Microsoft.AspNetCore.Mvc;
using Commerce.Infrastructure.Controller;
using SettingService.AppCore.UseCases.Queries;

namespace SettingService.Application.V1
{
    [ApiVersion("1.0")]
    [ApiController]
    public class SettingController : BaseController
    {
        [ApiVersion( "1.0" )]
        [HttpGet("/api/v{version:apiVersion}/countries/{id:guid}")]
        public async Task<ActionResult<CountryDto>> HandleAsync(Guid id,
            CancellationToken cancellationToken = new())
        {
            var request = new GetCountryById.Query {Id = id};

            return Ok(await Mediator.Send(request, cancellationToken));
        }
    }
}
