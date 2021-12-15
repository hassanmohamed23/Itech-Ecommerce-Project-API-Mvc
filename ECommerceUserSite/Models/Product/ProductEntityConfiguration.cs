using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models 
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ProductId);
            builder.Property(p => p.ProductId).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Price).IsRequired();
            builder.Property(p => p.Quantity).IsRequired();
            builder.Property(p => p.Description).IsRequired();

            builder.HasOne(p => p.Admin).WithMany(a => a.Products).HasForeignKey(p => p.AdminId);
            builder.HasOne(p => p.category).WithMany(a => a.Products).HasForeignKey(p => p.CatId);
            builder.HasOne(p => p.brands).WithMany(a => a.Products).HasForeignKey(p => p.BrandId); 
            builder.HasOne(p => p.stock).WithMany(s => s.Products).HasForeignKey(p => p.StockId);
            builder.HasOne(p => p.subCategory).WithMany(s => s.Products).HasForeignKey(p => p.SubCatId).OnDelete(DeleteBehavior.Restrict);
              
        }
    }
}
