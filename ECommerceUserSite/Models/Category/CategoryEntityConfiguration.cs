using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models 
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // throw new NotImplementedException();
            builder.HasKey(i => i.CategoryId);
            builder.Property(i => i.CategoryId).ValueGeneratedOnAdd();
            builder.Property(i => i.CategoryName).IsRequired().HasMaxLength(500);
        }
    }
}
