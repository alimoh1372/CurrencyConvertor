using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurrencyConvertor.Domain.ConvertRateAgg;
using CurrencyConvertor.Domain.CurrencyAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CurrencyConvertor.Infrastructure.EfCore.Mapping
{
    public class ConvertRateMapping:IEntityTypeConfiguration<ConvertRate>
    {
        public void Configure(EntityTypeBuilder<ConvertRate> builder)
        {
            builder.ToTable("Currencies");
            builder.HasKey(x => new {x.FkDestinationCurrencyId,x.FkSourceCurrencyId});



            //map source currency
            builder.HasOne(x => x.SourceCurrency)
                .WithMany(x => x.SourceConvertRates)
                .HasForeignKey(x => x.FkSourceCurrencyId);
            
            
            //map destination currency
            builder.HasOne(x => x.DestinationCurrency)
                .WithMany(x => x.DestinationConvertRates)
                .HasForeignKey(x => x.FkDestinationCurrencyId);


        }
    }
}
