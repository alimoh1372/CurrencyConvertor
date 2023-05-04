using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurrencyConvertor.Domain.CurrencyAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CurrencyConvertor.Infrastructure.EfCore.Mapping
{
    public class CurrencyMapping:IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.ToTable("Currencies");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ShortName).IsRequired().HasMaxLength(10);
            builder.Property(x => x.CompleteName).IsRequired(false).HasMaxLength(255);


            //map the relation from currency to the convert rate source currency to convert rate
            builder.HasMany(x => x.SourceConvertRates)
                .WithOne(x => x.SourceCurrency)
                .HasForeignKey(x => x.FkSourceCurrencyId);


            //map the relation from currency to convert rate = destination currency to convert rate
            builder.HasMany(x => x.DestinationConvertRates)
                .WithOne(x => x.DestinationCurrency)
                .HasForeignKey(x => x.FkDestinationCurrencyId);
        }
    }
}
