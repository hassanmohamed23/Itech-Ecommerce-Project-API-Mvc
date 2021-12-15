using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models 
{
    public class OrderItemEntityConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            // builder.ToTable("Order");
            builder.Property(oi => oi.price).IsRequired();
            builder.Property(oi => oi.Quantity).IsRequired();
            builder.HasKey(oi => new {oi.OrderId,oi.ProductId });
            builder.HasOne(oi => oi.order).WithMany(o => o.orderItems).HasForeignKey(oi => oi.OrderId);
            builder.HasOne(oi => oi.product).WithMany(p => p.orderItems).HasForeignKey(oi => oi.ProductId);
        }
    }
}
