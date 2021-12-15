using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models 
{
    public class OffersEntityConfiguration : IEntityTypeConfiguration<Offers>
    {
        public void Configure(EntityTypeBuilder<Offers> builder)
        {
            //throw new NotImplementedException();
            builder.HasKey(i => i.OfferId);
            builder.Property(i => i.OfferId).ValueGeneratedOnAdd();
            builder.Property(i => i.StartDate).IsRequired(); 
            builder.Property(i => i.EndDate).IsRequired();
            builder.Property(i => i.NewPrice).IsRequired();

            builder.HasOne(o => o.admin).WithMany(a => a.offers).HasForeignKey(o => o.AdminId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(o => o.product).WithMany(p => p.offers).HasForeignKey(o => o.ProductId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
