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
        }
    }
}
