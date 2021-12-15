using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models 
{
    public class StockEntityConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            //throw new NotImplementedException();
            builder.HasKey(s => s.StockId);
            builder.Property(s => s.StockId).ValueGeneratedOnAdd();
            builder.Property(s => s.StockName).IsRequired().HasMaxLength(20);
            builder.Property(s => s.StockAddress).IsRequired().HasMaxLength(50);
             
        }
    }
}
