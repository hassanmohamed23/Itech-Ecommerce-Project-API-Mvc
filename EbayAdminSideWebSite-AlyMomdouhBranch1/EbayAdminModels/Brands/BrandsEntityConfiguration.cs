using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BrandsEntityConfiguration : IEntityTypeConfiguration<Brands>
    {
        public void Configure(EntityTypeBuilder<Brands> builder)
        {
            //throw new NotImplementedException();
            builder.HasKey(i => i.BrandId);
            builder.Property(i => i.BrandId).ValueGeneratedOnAdd();
            builder.Property(i => i.BrandName).IsRequired().HasMaxLength(500);

        }
    }
}
