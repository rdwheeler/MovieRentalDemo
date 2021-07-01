using System.Threading.Tasks;
using Store.AppContracts.Common;
using Store.AppContracts.Dtos;
using RestEase;

namespace Store.AppContracts.RestApi
{
    public interface IAppApi
    {
        [Get("api/product-api/v1/products")]
        Task<ResultDto<ListResultDto<ProductDto>>> GetProductsAsync([Header("x-query")] string xQuery);
        [Get("api/rental-api/v1/rentals")]
        Task<ResultDto<ListResultDto<RentalDto>>> GetRentalsAsync([Header("x-query")] string xQuery);
    }
}
