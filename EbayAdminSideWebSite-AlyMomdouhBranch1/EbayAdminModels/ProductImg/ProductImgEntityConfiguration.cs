using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models 
{
    public class ProductImgEntityConfiguration : IEntityTypeConfiguration<ProductImg>
    {
        public void Configure(EntityTypeBuilder<ProductImg> builder)
        {
            builder.HasKey(pi => pi.ImgId);
            builder.Property(pi => pi.ImgId).ValueGeneratedOnAdd();
            builder.Property(pi => pi.src).IsRequired();
            builder.HasOne(pi => pi.product).WithMany(p => p.productImgs).HasForeignKey(pi => pi.ProductId);
             
        }
    }
}
