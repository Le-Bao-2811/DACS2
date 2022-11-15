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
    [Table(NameTable.productTable)]
    public class Product:BaseEntity
    {
        public Product()
        {
            colors=new HashSet<Color>();
            sizes=new HashSet<Size>();
            images=new HashSet<Image>();
        }
        
        public string ProductName { get; set; } // tên sp
        public string Description { get; set; } // tên sp
        public int? ImportPrice { get; set; } // giá nhập
        public int Price { get; set; }
        public int Amount { get; set; }
        public string Unit { get; set; } //đơn vị tính
        public int Sold { get; set; } // đã bán
        public string slug { get; set; }
        public string? pathImgP { get; set; }
        public int IdProductCategory { get; set; }
        public int IdSuplier { get; set; }
        public Supplier supplier { get; set; }
        public CategoryProduct categoryProduct { get; set; }
        public ICollection<Size> sizes { get; set; }
        public ICollection<Color> colors { get; set; }
        public ICollection<Image> images { get; set; }
    }
}
