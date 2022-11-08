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
    public class SizeConfig : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {          
            builder.HasOne(m => m.product)
                 .WithMany(m => m.sizes)
                 .HasForeignKey(m => m.IdProduct);
        }
    }
}
