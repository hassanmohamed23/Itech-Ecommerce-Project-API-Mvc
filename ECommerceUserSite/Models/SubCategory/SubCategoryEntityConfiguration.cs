using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models 
{
    public class SubCategoryEntityConfiguration : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            //throw new NotImplementedException();

            builder.HasKey(s => s.SubCategoryId);
            builder.Property(s => s.SubCategoryId).ValueGeneratedOnAdd();
            builder.Property(s => s.SubCatName).IsRequired().HasMaxLength(20);
            builder.HasOne(s => s.category).WithMany(c => c.subCategories).HasForeignKey(s => s.CatId);
             
    }
    }
}
