using Oona.AppWebTwo.Core.Domain.Entities;
using Oona.AppWebTwo.Infrastructure.Data.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oona.AppWebTwo.Infrastructure.Data.Repository
{
    public class CountriesRepository : BaseRepository<Country, int>, ICountriesRepository
    {
        AppDbContext _dbContext;

        public CountriesRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
