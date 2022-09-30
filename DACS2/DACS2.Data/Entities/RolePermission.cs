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
    [Table(NameTable.RolePermissionTable)]
    public class RolePermission : BaseEntity
    {
        public int RoleId { get; set; }
        public int MStPermissionId { get; set; }
        public Role role { get; set; }
        public MstPerMission mstPerMission { get; set; }

    }
}
