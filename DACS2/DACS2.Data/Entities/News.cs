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
    [Table(NameTable.NewsTable)]
    public class News :BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string pathImg { get; set; }
        public int IdCategoryNew { get; set; }
        public CategoryNews categoryNews { get; set; }
    }
}
