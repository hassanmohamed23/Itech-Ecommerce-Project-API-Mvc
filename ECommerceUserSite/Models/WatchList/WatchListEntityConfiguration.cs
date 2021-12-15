using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models 
{
   public  class WatchListEntityConfiguration : IEntityTypeConfiguration<WatchList>
    {
        public void Configure(EntityTypeBuilder<WatchList> builder)
        {
            //throw new NotImplementedException();
            builder.HasKey(wl => new { wl.UserId, wl.ProductId });
            builder.HasOne(wl => wl.user).WithMany(u => u.watchLists).HasForeignKey(wl => wl.UserId);
            builder.HasOne(wl => wl.product).WithMany(p => p.watchLists).HasForeignKey(wl => wl.ProductId);
             
        }
    }
}
