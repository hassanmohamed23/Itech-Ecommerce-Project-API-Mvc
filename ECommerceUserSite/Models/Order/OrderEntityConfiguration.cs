using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models 
{
    public class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            //builder.ToTable("Order");
            builder.HasKey(i => i.OrderId);
            builder.Property(i => i.OrderId).ValueGeneratedOnAdd();
            builder.Property(i => i.OrderDate).IsRequired();
           // builder.Property(i => i.OrderStatus).IsRequired();
            builder.Property(i => i.TotalPrice).IsRequired();

            builder.HasOne(o => o.user).WithMany(u => u.orders).HasForeignKey(o => o.UserId);
            builder.HasOne(o => o.paymentWay).WithMany(pw => pw.orders).HasForeignKey(o => o.PaymentId);
             
        }
    }
}
