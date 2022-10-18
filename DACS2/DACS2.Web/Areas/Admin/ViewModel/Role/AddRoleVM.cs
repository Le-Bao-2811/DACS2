using DACS2.Share.Attributes;
using DACS2.Web.WebConfig.Const;

namespace DACS2.Web.Areas.Admin.ViewModel.Role
{
    public class AddRoleVM
    {
        [AppRequired]
        public string RoleName { get; set; }

        [AppRequired]
        public string Description { get; set; }

        // Chuỗi chứa permissionId, phân tách bởi dấu phẩy
        [AppRequired(ErrorMessage = VM.RoleVM.PERMISSION_IDS_REQUIRED_ERR_MESG)]
        [AppRegex(VM.RoleVM.PERMISSION_IDS_REGEX, ErrorMessage = VM.RoleVM.PERMISSION_IDS_REGEX_ERR_MESG)]
        public string PermissionIds { get; set; }
    }
}
