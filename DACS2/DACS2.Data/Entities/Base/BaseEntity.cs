using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACS2.Data.Entities.Base
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public int? CreateBy { get; set; }
        public DateTime? DeleteAt { get; set; }
        public DateTime? DetleteBy { get; set; }
        public int? DislayOrder { get; set; }
    }
}
