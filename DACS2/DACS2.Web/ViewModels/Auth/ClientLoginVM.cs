using DACS2.Share.Attributes;

namespace DACS2.Web.ViewModels.Auth
{
    public class ClientLoginVM
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RemeberMe { get; set; }
    }
}
