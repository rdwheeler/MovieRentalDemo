using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using Commerce.Core.Domain;
using Commerce.Core.Specification;

namespace RentalService.AppCore.Core.Specs
{
    public sealed class RentalByIdQuerySpec<TResponse> : SpecificationBase<Rental>
    {
        private readonly Guid _id;

        public RentalByIdQuerySpec([NotNull] IItemQuery<Guid, TResponse> queryInput)
        {
            ApplyIncludeList(queryInput.Includes);

            _id = queryInput.Id;
        }

        public override Expression<Func<Rental, bool>> Criteria => p => p.Id == _id;
    }
}
