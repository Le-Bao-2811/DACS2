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
    [Table(NameTable.RoleTable)]
    public class Role :BaseEntity
    {
        public Role()
        {
            Users = new HashSet<User>();
            rolePermissions = new HashSet<RolePermission>();
        }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public ICollection<RolePermission> rolePermissions { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
