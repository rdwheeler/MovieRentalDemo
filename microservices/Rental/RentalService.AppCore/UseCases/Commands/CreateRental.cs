using System;
using System.Threading;
using System.Threading.Tasks;
using Store.AppContracts.Dtos;
using FluentValidation;
using MediatR;
using Commerce.Core.Domain;
using Commerce.Core.Repository;
using RentalService.AppCore.Core;

namespace RentalService.AppCore.UseCases.Commands
{
    public class CreateRental
    {
        public record Command : ICreateCommand<Command.CreateRentalModel, RentalDto>
        {
            public CreateRentalModel Model { get; init; } = default!;

            public record CreateRentalModel(Guid CustomerId, Guid ProductId, DateTime BeginTime, DateTime EndTime, DateTime ReturnDueTime, bool IsReturned, decimal RentalCost);

            internal class Validator : AbstractValidator<Command>
            {
                public Validator()
                {
                    RuleFor(v => v.Model.CustomerId)
                        .NotEmpty().WithMessage("CustomerId is required.");
                    RuleFor(v => v.Model.ProductId)
                        .NotEmpty().WithMessage("ProductId is required.");
                    RuleFor(v => v.Model.BeginTime)
                        .NotEmpty().WithMessage("BeginTime is required.");
                    RuleFor(v => v.Model.EndTime)
                        .NotEmpty().WithMessage("EndTime is required.")
                        .GreaterThan(v => v.Model.BeginTime).WithMessage("EndTime must be greater than BeginTime.");
                    RuleFor(v => v.Model.ReturnDueTime)
                        .NotEmpty().WithMessage("ReturnDueTime is required.")
                        .GreaterThan(v => v.Model.BeginTime).WithMessage("ReturnDueTime must be greater than BeginTime.");
                }
            }

            internal class Handler : IRequestHandler<Command, ResultModel<RentalDto>>
            {
                private readonly IRepository<Rental> _RentalRepository;

                public Handler(IRepository<Rental> RentalRepository)
                {
                    _RentalRepository = RentalRepository ?? throw new ArgumentNullException(nameof(RentalRepository));
                }

                public async Task<ResultModel<RentalDto>> Handle(Command request, CancellationToken cancellationToken)
                {
                    var created = await _RentalRepository.AddAsync(
                        Rental.Create(
                            request.Model.CustomerId,
                            request.Model.ProductId,
                            request.Model.BeginTime,
                            request.Model.EndTime,
                            request.Model.ReturnDueTime,
                            request.Model.IsReturned,
                            request.Model.RentalCost));

                    return ResultModel<RentalDto>.Create(new RentalDto
                    {
                        Id = created.Id,
                        CustomerId = created.CustomerId,
                        ProductId = created.ProductId,
                        BeginTime = created.BeginTime,
                        EndTime = created.EndTime,
                        ReturnDueTime = created.ReturnDueTime,
                        IsReturned = created.IsReturned,
                        RentalCost = created.RentalCost
                    });
                }
            }
        }
    }
}
