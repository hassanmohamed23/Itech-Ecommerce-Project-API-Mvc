using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models 
{
    public class CommentEntityConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            //throw new NotImplementedException();
            builder.Property(i => i.Description).IsRequired();
            builder.Property(i => i.Date).IsRequired();

            builder.HasKey(c => new { c.ProductId, c.UserId });
            builder.HasOne(u => u.user).WithMany(u => u.comments).HasForeignKey(r => r.UserId);
            builder.HasOne(r => r.product).WithMany(p => p.comments).HasForeignKey(r => r.ProductId);
        }
    }
}
