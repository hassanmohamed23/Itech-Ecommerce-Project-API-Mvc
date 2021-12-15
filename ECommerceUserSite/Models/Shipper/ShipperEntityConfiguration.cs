using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models 
{
    public class ShipperEntityConfiguration : IEntityTypeConfiguration<Shipper>
    {
        public void Configure(EntityTypeBuilder<Shipper> builder)
        {
            // builder.ToTable("Order");
            builder.HasKey(s => s.ShipperId);
            builder.Property(s => s.ShipperId).ValueGeneratedOnAdd();
            builder.Property(s => s.ShipperName).IsRequired().HasMaxLength(20);
            builder.Property(s => s.URL).IsRequired().HasMaxLength(20);
             
        }
    }
}
