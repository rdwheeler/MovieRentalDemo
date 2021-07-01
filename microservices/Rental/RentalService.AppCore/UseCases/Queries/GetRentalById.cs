using System;
using System.Collections.Generic;
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
    public class GetRentalById
    {
        public record Query : IItemQuery<Guid, RentalDto>
        {
            public List<string> Includes { get; init; } = new(new[] {"Returns", "Code"});
            public Guid Id { get; init; }

            internal class Validator : AbstractValidator<Query>
            {
                public Validator()
                {
                    RuleFor(x => x.Id)
                        .NotNull()
                        .NotEmpty().WithMessage("Id is required.");
                }
            }

            internal class Handler : IRequestHandler<Query, ResultModel<RentalDto>>
            {
                private readonly IRepository<Rental> _RentalRepository;

                public Handler(IRepository<Rental> RentalRepository)
                {
                    _RentalRepository = RentalRepository ?? throw new ArgumentNullException(nameof(RentalRepository));
                }

                public async Task<ResultModel<RentalDto>> Handle(Query request,
                    CancellationToken cancellationToken)
                {
                    if (request == null) throw new ArgumentNullException(nameof(request));

                    var spec = new RentalByIdQuerySpec<RentalDto>(request);

                    var Rental = await _RentalRepository.FindOneAsync(spec);

                    return ResultModel<RentalDto>.Create(new RentalDto
                    {
                        Id = Rental.Id,
                        CustomerId = Rental.CustomerId,
                        ProductId = Rental.ProductId,
                        BeginTime = Rental.BeginTime,
                        EndTime = Rental.EndTime,
                        ReturnDueTime = Rental.ReturnDueTime,
                        IsReturned = Rental.IsReturned,
                        RentalCost = Rental.RentalCost
                    });
                }
            }
        }
    }
}
