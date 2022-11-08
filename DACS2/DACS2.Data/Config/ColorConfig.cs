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
    public class ColorConfig : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
           
            builder.HasOne(m => m.product)
                .WithMany(m => m.colors)
                .HasForeignKey(m => m.IdProduct);
        }
    }
}
