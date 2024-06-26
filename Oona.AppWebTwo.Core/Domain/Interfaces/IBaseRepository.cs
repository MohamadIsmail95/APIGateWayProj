using Oona.AppWebTwo.Core.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oona.AppWebTwo.Core.Domain.Interfaces
{
    public interface IBaseRepository<TEntity, TKey> where TEntity : class
    {
        IQueryable<TEntity> GetFilterListAsQuerable(ApiRequestFilter input);
    }
}
