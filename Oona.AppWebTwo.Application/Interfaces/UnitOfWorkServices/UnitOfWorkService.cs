using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Oona.AppWebTwo.Application.Sevices.CountryServices;
using Oona.AppWebTwo.Core.Domain.Entities;
using Oona.AppWebTwo.Core.Domain.Interfaces;
using Oona.AppWebTwo.Infrastructure.Data.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oona.AppWebTwo.Application.Interfaces.UnitOfWorkServices
{
    public class UnitOfWorkService : IUnitOfWorkService
    {
        ICountryServices.ICountryServices _countryServices;
        IMapper _mapper;
        IUnitOfWork _unitOfWork;
        IMemoryCache _cache;
        ILogger<CountryServices> _logger;
        public UnitOfWorkService(IMapper mapper, IUnitOfWork unitOfWork, IMemoryCache cache , ILogger<CountryServices> logger)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _cache = cache;
            _logger = logger;
        }

        public ICountryServices.ICountryServices CountryServices
        {

            get
            {
                if (_countryServices == null)
                    _countryServices = new CountryServices(_unitOfWork.CountryRepository, _mapper, _cache , _logger);

                return _countryServices;
            }
        }
    }
}
