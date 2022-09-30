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
    public class DesignsConfig : IEntityTypeConfiguration<Designs>
    {
        public void Configure(EntityTypeBuilder<Designs> builder)
        {
            builder.HasOne(m => m.product)
                .WithMany(m => m.designs)
                .HasForeignKey(m => m.IdProduct);
        }
    }
}
