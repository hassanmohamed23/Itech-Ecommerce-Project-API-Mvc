using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CartEntityConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            //throw new NotImplementedException();
            //builder.HasKey(i => i.AdminId);
            //builder.Property(i => i.AdminId).ValueGeneratedOnAdd();
            builder.Property(i => i.price).IsRequired();
            builder.Property(i => i.Quantity).IsRequired();

            builder.HasKey(c => new {c.ProductId,c.UserId });
            builder.HasOne(u => u.user).WithMany(u => u.carts).HasForeignKey(r => r.UserId);
            builder.HasOne(r => r.product).WithMany(p => p.carts).HasForeignKey(r => r.ProductId);
        }
    }
}
