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
    [Table(NameTable.PolicyTable)]
    public class Policy : BaseEntity
    {
        public string PolicyName { get; set; }
        public string Content { get; set; }
    }
}
