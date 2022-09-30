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
    public class InvoiceDetailsConfig : IEntityTypeConfiguration<InvoiceDetails>
    {
        public void Configure(EntityTypeBuilder<InvoiceDetails> builder)
        {
            builder.HasKey(x => new
            {
                x.Id,
                x.IdInvoice
            });
            builder.HasOne(m => m.invoice)
               .WithMany(m => m.InvoiceDetails)
               .HasForeignKey(m => m.IdInvoice);

            
        }
    }
}
