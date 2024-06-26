using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Oona.AppWebTwo.Core.Domain.Interfaces;
using Oona.AppWebTwo.Infrastructure.Data.IRepository;
using Oona.AppWebTwo.Infrastructure.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oona.AppWebTwo.Infrastructure.Data
{
    public class UnitOfWork :IUnitOfWork 
    {
        private readonly AppDbContext _dbContext;
        IMapper  _mapper;
        ICountriesRepository _countriesRepository { get; set; }


        public UnitOfWork(AppDbContext dbContext , IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public ICountriesRepository CountryRepository
        {
            get
            {
                if (_countriesRepository == null)
                    _countriesRepository = new CountriesRepository(_dbContext);

                return _countriesRepository;
            }
        }




        public IBaseRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : class
        {
            return new BaseRepository<TEntity, TKey>(_dbContext);
        }
    }
}
