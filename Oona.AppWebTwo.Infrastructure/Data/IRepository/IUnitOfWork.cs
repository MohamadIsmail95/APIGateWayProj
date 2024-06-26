using Oona.AppWebTwo.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oona.AppWebTwo.Infrastructure.Data.IRepository
{
    public interface IUnitOfWork
    {
        ICountriesRepository CountryRepository { get; }

        IBaseRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : class;
    }
}
