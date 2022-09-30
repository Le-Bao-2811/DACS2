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
    [Table(NameTable.MstPerMissionTable)]
    public class MstPerMission
    {
        public MstPerMission()
        {
            rolePermissions = new HashSet<RolePermission>();
        }
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Table { get; set; }
        public string Desc { get; set; }
        public string GroupName { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<RolePermission> rolePermissions { get; set; }

    }
}
