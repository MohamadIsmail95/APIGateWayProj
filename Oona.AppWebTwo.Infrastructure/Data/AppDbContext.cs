using Microsoft.EntityFrameworkCore;
using Oona.AppWebTwo.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Oona.AppWebTwo.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {

        public DbSet<Country> Countries { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Add Entities Configuration
        }
    }
}