using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models 
{
    public class PaymentWayEntityConfiguration : IEntityTypeConfiguration<PaymentWay>
    {
        public void Configure(EntityTypeBuilder<PaymentWay> builder)
        {
            //builder.ToTable("Order");
            builder.HasKey(p => p.PaymentId);
            builder.Property(i => i.PaymentId).ValueGeneratedOnAdd();
            // builder.Property(i => i.PaymentId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); // this for data annation 
            builder.Property(i => i.Name).IsRequired();
            builder.Property(i => i.Date).IsRequired();
        }
    }
}
