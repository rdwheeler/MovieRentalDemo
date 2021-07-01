using System;
using System.Threading.Tasks;
using Store.AppContracts.Common;
using Store.AppContracts.Dtos;
using RestEase;

namespace Store.AppContracts.RestApi
{
    public interface ICountryApi
    {
        [Get("api/v1/countries/{countryId}")]
        Task<ResultDto<CountryDto>> GetCountryByIdAsync([Path] Guid countryId);
    }
}
