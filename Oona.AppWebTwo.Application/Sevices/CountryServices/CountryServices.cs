using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Oona.AppWebTwo.Application.Helper;
using Oona.AppWebTwo.Application.Interfaces.ICountryServices;
using Oona.AppWebTwo.Application.Sevices.CountryServices.ViewModels;
using Oona.AppWebTwo.Core.Domain.Dtos;
using Oona.AppWebTwo.Core.Domain.Entities;
using Oona.AppWebTwo.Core.Domain.Interfaces;
using Oona.AppWebTwo.Infrastructure.Data.IRepository;
using Oona.AppWebTwo.Infrastructure.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Oona.AppWebTwo.Application.Sevices.CountryServices.ViewModels.CountriesViewModel;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Oona.AppWebTwo.Application.Sevices.CountryServices
{
    public class CountryServices : ICountryServices
    {
        private readonly ICountriesRepository _repository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private readonly ILogger<CountryServices> _logger;
        public CountryServices(ICountriesRepository repository ,  IMapper mapper, IMemoryCache cache, ILogger<CountryServices> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _cache = cache;
            _logger = logger;
        }

        public async Task<ApiResponse> GetLisCountries(ApiRequestFilter input)
        {
                var data =  _repository.GetFilterListAsQuerable(input);
               
                //Sort and paginition
                if (!string.IsNullOrEmpty(input.SortingField))
                {
                    if (input.SortingDir == "asc")
                        data = data.OrderBy2(input.SortingField);

                    else if (input.SortingDir == "desc")
                        data = data.OrderByDescending2(input.SortingField);

                    var result = data.Skip((input.PageNumber - 1) * input.PageSize)
                         .Take(input.PageSize).ToList();

                    

                    return new ApiResponse(result, data.Count(),null);
                }

                else
                {

                    var result = data.Skip((input.PageNumber - 1) * input.PageSize)
                         .Take(input.PageSize).ToList();

                    return new ApiResponse(result, data.Count(), null);
                }
            
           
        }

        public async Task<T> GetOrCreateAsync<T>(string cacheKey,T retrieveDataFunc, TimeSpan? slidingExpiration = null)

        {
            if (!_cache.TryGetValue(cacheKey, out T cachedData))
            {
                _logger.LogInformation("++++cache miss. fetching data for key: {CacheKey} from database.++++", cacheKey);

                // Data not in cache, retrieve it
                cachedData =  retrieveDataFunc;

                // Set cache options
                var cacheOptions = new MemoryCacheEntryOptions()
               .SetSlidingExpiration(TimeSpan.FromSeconds(10))
               .SetAbsoluteExpiration(TimeSpan.FromSeconds(30))
               .SetPriority(CacheItemPriority.Normal)
               .SetSize(2048);

                // Save data in cache
                _cache.Set(cacheKey, cachedData, cacheOptions);
                return cachedData;


            }

            return cachedData;

        }


    }
}
