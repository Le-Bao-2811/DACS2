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
    [Table(NameTable.StatusTable)]
    public class Status :BaseEntity
    {
        public Status()
        {
            invoices = new HashSet<Invoice>();
        }
        public string StatusName { get; set; }
        public ICollection<Invoice> invoices { get; set; }
    }
}
