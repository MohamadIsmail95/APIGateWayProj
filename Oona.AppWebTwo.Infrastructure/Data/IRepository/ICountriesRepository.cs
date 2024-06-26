using Oona.AppWebTwo.Core.Domain.Entities;
using Oona.AppWebTwo.Core.Domain.Interfaces;
using Oona.AppWebTwo.Infrastructure.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oona.AppWebTwo.Infrastructure.Data.IRepository
{
    public interface ICountriesRepository : IBaseRepository<Country,int>
    {
    }
}
