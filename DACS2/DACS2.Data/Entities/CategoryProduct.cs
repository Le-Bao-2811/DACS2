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
    [Table(NameTable.CategoryProductTable)]
    public class CategoryProduct:BaseEntity
    {
        public CategoryProduct()
        {
            Products=new HashSet<Product>();
        }
        public string CategoryName { get; set; }
        public string? pathImg { get; set; }
        public int SoLuong { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
