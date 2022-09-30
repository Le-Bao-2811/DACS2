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
    [Table(NameTable.CategoryNewsTable)]
    public class CategoryNews:BaseEntity
    {
        public CategoryNews()
        {
            news = new HashSet<News>();
        }
        public string ProductNewsName { get; set; }
        public ICollection<News> news { get; set; }
    }
}
