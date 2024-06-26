using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Oona.AppWebTwo.Core.Domain.Dtos;
using Oona.AppWebTwo.Core.Domain.Interfaces;
using Oona.AppWebTwo.Infrastructure.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oona.AppWebTwo.Infrastructure.Data.Repository
{
    public class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet;
        private readonly AppDbContext _dbContext;
        public BaseRepository(AppDbContext dbContext)
        {
            _dbSet = dbContext.Set<TEntity>();
            _dbContext = dbContext;
        }

        public IQueryable<TEntity> GetFilterListAsQuerable(ApiRequestFilter input)
        {
            if (!string.IsNullOrEmpty(input.SearchQuery))
            {
                var expression = ExpressionUtils.BuildPredicate<TEntity>("Name", "StartsWith", input.SearchQuery);
                var data = _dbSet.Where(expression);
                return data;
            }
            return _dbSet.AsQueryable();
        }
    }
}
