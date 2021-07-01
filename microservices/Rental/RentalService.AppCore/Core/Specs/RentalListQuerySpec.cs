using Commerce.Core.Domain;
using Commerce.Core.Specification;

namespace RentalService.AppCore.Core.Specs
{
    public sealed class RentalListQuerySpec<TResponse> : GridSpecificationBase<Rental>
    {
        public RentalListQuerySpec(IListQuery<ListResultModel<TResponse>> gridQueryInput)
        {
            ApplyIncludeList(gridQueryInput.Includes);

            ApplyFilterList(gridQueryInput.Filters);

            ApplySortingList(gridQueryInput.Sorts);

            ApplyPaging(gridQueryInput.Page, gridQueryInput.PageSize);
        }
    }
}
