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
    [Table(NameTable.UserTable)]
    public class User :BaseEntity
    {
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public int IdRole { get; set; }
        public Role role { get; set; }
    }
}
