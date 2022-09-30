using DACS2.Data.Entities.Base;
using DACS2.Share.Consts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACS2.Data.Entities
{
    [Table(NameTable.SupplierTable)]
    public class Supplier:BaseEntity
    {
        public Supplier() 
        {
            products = new HashSet<Product>();
        }
        public string SupplierName { get; set; }
        public ICollection<Product> products { get; set; }
    }
}
