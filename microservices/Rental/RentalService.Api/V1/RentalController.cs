using System;
using System.Threading;
using System.Threading.Tasks;
using Store.AppContracts.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Commerce.Core.Domain;
using Commerce.Infrastructure;
using Commerce.Infrastructure.Controller;
using RentalService.AppCore.UseCases.Commands;
using RentalService.AppCore.UseCases.Queries;

namespace RentalService.Application.V1
{
    [Authorize("RequireInteractiveUser")]
    [ApiVersion("1.0")]
    [ApiController]
    public class RentalController : BaseController
    {
        [HttpGet("/api/v{version:apiVersion}/Rentals/{id:guid}")]
        public async Task<ActionResult<RentalDto>> HandleGetRentalByIdAsync(Guid id,
            CancellationToken cancellationToken = new())
        {
            var request = new GetRentalById.Query { Id = id };

            return Ok(await Mediator.Send(request, cancellationToken));
        }

        [HttpGet("/api/v{version:apiVersion}/Rentals")]
        public async Task<ActionResult> HandleGetRentalsAsync([FromHeader(Name = "x-query")] string query,
            CancellationToken cancellationToken = new())
        {
            var queryModel = HttpContext.SafeGetListQuery<GetRentals.Query, ListResultModel<RentalDto>>(query);

            return Ok(await Mediator.Send(queryModel, cancellationToken));
        }

        [HttpPost("/api/v{version:apiVersion}/Rentals")]
        public async Task<ActionResult> HandleCreateRentalAsync([FromBody] CreateRental.Command request, CancellationToken cancellationToken = new())
        {
            return Ok(await Mediator.Send(request, cancellationToken));
        }
    }
}
