using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class AdminEntityConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        { 
            builder.HasKey(i => i.AdminId);
            builder.Property(i => i.AdminId).ValueGeneratedOnAdd();
            builder.Property(i => i.FistName).IsRequired().HasMaxLength(500);
            builder.Property(i => i.LastName).IsRequired().HasMaxLength(500);
            builder.Property(i => i.Password).IsRequired().HasMaxLength(15);
            builder.Property(i => i.Salary).IsRequired().HasDefaultValue(3000);
            builder.Property(i => i.UserName).IsRequired().HasMaxLength(10);
            builder.Property(i => i.Email).IsRequired().HasMaxLength(30);


            //builder.ToTable("Employee");
            // builder.Property(s => s.ProductId).HasColumnName("Id").HasDefaultValue(0).IsRequired();
            //   builder.Property(p => p.Sex).HasDefaultValue(false);
            //builder.HasMany(cr => cr.Products).WithOne(c=>c.Admin); 
            //builder.HasMany(x => x.Products).WithOne().HasForeignKey(y => y.AdminId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
