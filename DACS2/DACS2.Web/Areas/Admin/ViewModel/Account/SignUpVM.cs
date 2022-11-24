using DACS2.Share.Attributes;
using System.ComponentModel.DataAnnotations;

namespace DACS2.Web.Areas.Admin.ViewModel.Account
{
    public class SignUpVM
    {
        [AppRequired]
        public string UserName { get; set; }
        [AppRequired]
        public string Password { get; set; }
        [Compare(nameof(Password), ErrorMessage = "Mật khẩu không khớp")]
        public string ComformPassword { get; set; }
        [AppRequired]
        public string Gmail { get; set; }
        [AppRequired]
        public string SDT { get; set; }
        public int IdRole { get; set; }
        public bool? IsSubmit { get; set; }
        public byte[]? PasswordHash { get; internal set; }
        public byte[]? PasswordSalt { get; internal set; }
    }
}
