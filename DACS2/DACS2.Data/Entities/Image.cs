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
    [Table(NameTable.ImageTable)]
    public class Image:BaseEntity
    {
        public int Id { get; set; }
        public string pathImage { get; set; }
        public int IdProduct { get; set; }
        public int? IdDesign { get; set; }
        public Product Product { get; set; }
    }
}
