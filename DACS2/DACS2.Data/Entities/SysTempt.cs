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
    [Table(NameTable.SystemTable)]
    public class SysTempt :BaseEntity
    {
        public string Gmail { get; set; }
        public string Phone { get; set; }
        public string FullName { get; set; }
    }
}
