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
    [Table(NameTable.InvoiceTable)]
    public class Invoice :BaseEntity
    {
        public Invoice()
        {
            InvoiceDetails = new HashSet<InvoiceDetails>();
        }
        public string NameCustomer { get; set; }
        public string Address { get; set; }
        public string NumberPhone { get; set; }
        public string? useVoucher { get; set; }
        public decimal TotalMoney { get; set; }
        public int StatusId { get; set; }
        public Status status { get; set; }
        public ICollection<InvoiceDetails> InvoiceDetails { get; set; }
    }
}
