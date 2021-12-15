using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models 
{
    public class RatesEntityConfiguration : IEntityTypeConfiguration<Rates>
    {
        public void Configure(EntityTypeBuilder<Rates> builder)
        {
            //throw new NotImplementedException();
            builder.HasKey(r => new { r.UserId, r.ProductId });
            builder.Property(r => r.Rate).IsRequired().HasDefaultValue(0);
            builder.HasOne<User>(u => u.user).WithMany(u => u.rates).HasForeignKey(r => r.UserId);
            builder.HasOne(r => r.product).WithMany(p => p.rates).HasForeignKey(r => r.ProductId);
            //builder.HasOne<Product>(p => p.product).WithMany(u => u.rates).HasForeignKey(r => r.ProductId);
             
        }
    }
}
