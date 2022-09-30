using DACS2.Share.Consts;
using DACS2.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACS2.Data.Entities
{
    [Table(NameTable.InvoiceDetailsTable)]
    public class InvoiceDetails
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Amount { get; set; }
        public decimal Money { get; set; }
        public int IdInvoice { get; set; }
        public string Designs { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public Invoice invoice { get; set; }
    }
}
