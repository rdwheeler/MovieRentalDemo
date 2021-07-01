using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Store.AppContracts.Dtos;
using FluentValidation;
using MediatR;
using Commerce.Core.Domain;
using Commerce.Core.Repository;
using RentalService.AppCore.Core;
using RentalService.AppCore.Core.Specs;

namespace RentalService.AppCore.UseCases.Queries
{
    public class GetRentals
    {
        public class Query : IListQuery<ListResultModel<RentalDto>>
        {
            public List<string> Includes { get; init; } = new(new[] {"Returns", "Code"});
            public List<FilterModel> Filters { get; init; } = new();
            public List<string> Sorts { get; init; } = new();
            public int Page { get; init; } = 1;
            public int PageSize { get; init; } = 20;

            internal class Validator : AbstractValidator<Query>
            {
                public Validator()
                {
                    RuleFor(x => x.Page)
                        .GreaterThanOrEqualTo(1).WithMessage("Page should at least greater than or equal to 1.");

                    RuleFor(x => x.PageSize)
                        .GreaterThanOrEqualTo(1).WithMessage("PageSize should at least greater than or equal to 1.");
                }
            }

            internal class Handler : IRequestHandler<Query, Commerce.Core.Domain.ResultModel<ListResultModel<RentalDto>>>
            {
                private readonly IGridRepository<Rental> _RentalRepository;

                public Handler(IGridRepository<Rental> RentalRepository)
                {
                    _RentalRepository =
                        RentalRepository ?? throw new ArgumentNullException(nameof(RentalRepository));
                }

                public async Task<Commerce.Core.Domain.ResultModel<ListResultModel<RentalDto>>> Handle(Query request,
                    CancellationToken cancellationToken)
                {
                    if (request == null) throw new ArgumentNullException(nameof(request));

                    var spec = new RentalListQuerySpec<RentalDto>(request);

                    var Rentals = await _RentalRepository.FindAsync(spec);

                    var RentalModels = Rentals.Select(x => new RentalDto
                    {
                        Id = x.Id,
                        CustomerId = x.CustomerId,
                        ProductId = x.ProductId,
                        BeginTime = x.BeginTime,
                        EndTime = x.EndTime,
                        ReturnDueTime = x.ReturnDueTime,
                        IsReturned = x.IsReturned,
                        RentalCost = x.RentalCost
                    });

                    var totalRentals = await _RentalRepository.CountAsync(spec);

                    var resultModel = ListResultModel<RentalDto>.Create(
                        RentalModels.ToList(), totalRentals, request.Page, request.PageSize);

                    return Commerce.Core.Domain.ResultModel<ListResultModel<RentalDto>>.Create(resultModel);
                }
            }
        }
    }
}
