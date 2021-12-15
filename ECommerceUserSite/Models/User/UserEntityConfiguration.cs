using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public  class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //builder.HasKey(u => u.Id);
             // builder.Property(u => u.Id).ValueGeneratedOnAdd();
            //builder.Property(u => u.FistName).IsRequired().HasMaxLength(15);
            //builder.Property(u => u.LastName).IsRequired().HasMaxLength(15);
            builder.Property(u => u.UserName).IsRequired().HasMaxLength(15);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(15);
           //builder.Property(u => u.Password).IsRequired().HasMaxLength(15);
           // builder.Property(u => u.Img).IsRequired().HasMaxLength(30);
           // builder.Property(u => u.Phone).HasMaxLength(15);
           // builder.Property(u => u.Country).IsRequired().HasMaxLength(20);
          //  builder.Property(u => u.ActivationCode).HasMaxLength(15).HasDefaultValue("");


            //public string Country { get; set; }
            //public string City { get; set; }
            //public int ZIP { get; set; }
             
             

        }
    }
}
