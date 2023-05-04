using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurrencyConvertor.Domain.ConvertRateAgg;
using CurrencyConvertor.Domain.CurrencyAgg;
using CurrencyConvertor.Infrastructure.EfCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace CurrencyConvertor.Infrastructure.EfCore
{

    public class CurrencyContext : DbContext
    {
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<ConvertRate> ConvertRates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //get all similar mapping type to apply all mapping with one code
            var assembly = typeof(CurrencyMapping).Assembly;

            //apply all mapping configuration using assembly
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
