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
    //Kiểu dáng sản phẩm
    [Table(NameTable.DesignsTable)]
    public class Designs :BaseEntity
    {
      
        public string DesignsName { get; set; }
        public int Amount { get; set; }
        public int IdProduct { get; set; }
        public Product product { get; set; }
    }
}
