using DACS2.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACS2.Data.Config
{
    public class ImageConfig : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
          
            builder.HasOne(m => m.Product)
                .WithMany(m => m.images)
                .HasForeignKey(m => m.IdProduct);
        }
    }
}
