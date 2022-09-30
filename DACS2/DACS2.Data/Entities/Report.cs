using DACS2.Data.Entities.Base;
using DACS2.Share.Consts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACS2.Data.Entities
{
    [Table(NameTable.ReportTable)]
    public class Report :BaseEntity
    {
        public string FullName { get; set; }
        public string ReportContent { get; set; }
        public bool Status{ get; set; }
    }
}
