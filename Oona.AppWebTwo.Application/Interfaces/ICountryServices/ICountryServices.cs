using Oona.AppWebTwo.Application.Helper;
using Oona.AppWebTwo.Core.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oona.AppWebTwo.Application.Interfaces.ICountryServices
{
    public interface ICountryServices
    {
        Task<ApiResponse> GetLisCountries(ApiRequestFilter input);
        Task<T> GetOrCreateAsync<T>(string cacheKey,T retrieveDataFunc, TimeSpan? slidingExpiration = null);
    }
}
