using DACS2.Data.Entities;
using DACS2.Data.Reponsitory;
using DACS2.Share.Consts;
using DACS2.Share.Extensions;
using DACS2.Web.Areas.Admin.ViewModel.Role;
using DACS2.Web.Common;
using DACS2.Web.WebConfig;
using log4net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using X.PagedList;

namespace DACS2.Web.Areas.Admin.Controllers
{

    public class RoleController : BaseController
    {

        public RoleController(BaseReponsitory _repo) : base(_repo)
        {
        }
        [AppAuthorize(AuthConst.Role.VIEW_LIST)]
        public IActionResult Index(int page=1,int size=10)
        {
            var data =  _repo.GetAll<Role, ListRoleItemVM>(MapperConfig.RoleIndexConf).ToPagedList(page,size);
            return View(data);
        }
        [AppAuthorize(AuthConst.Role.CREATE)]
        public IActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        [AppAuthorize(AuthConst.Role.CREATE)]
        public async Task<IActionResult> AddRole(AddRoleVM model)
        {
            if (model.PermissionIds == null)
            {
                SetErrorMesg("Có lỗi xãy ra");
                return View(model);
            }
            var arrIdPermission = model.PermissionIds.Split(',');

            var role = new Role
            {
                RoleName = model.RoleName,
                Description = model.Description
            };
            try
            {
                await _repo.AddAsync(role);
                foreach (var item in arrIdPermission)
                {
                    var idPer = Convert.ToInt32(item);
                    role.rolePermissions.Add(new RolePermission
                    {
                        MStPermissionId = idPer
                    });
                }
                await _repo.AddAsync(role.rolePermissions);
                SetSuccessMesg($"Thêm vai trò [{role.RoleName}] thành công");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        [AppAuthorize(AuthConst.Role.UPDATE)]
        public async Task<IActionResult> UpdateRole(int? id)
        {
            if (!id.HasValue)
            {
                SetErrorMesg("Id không được trống");
                return RedirectToAction(nameof(Index));
            }
            var data = await _repo.GetOneAsync<Role, RoleEditVM>(id.Value, r => new RoleEditVM
            {
                Id = r.Id,
                RoleName = r.RoleName,
                Description = r.Description,
                PermissionIds = string.Join(',', r.rolePermissions.Select(rp => rp.MStPermissionId)),
            });
            if (data == null)
            {
                SetErrorMesg("Không tìm thấy dữ liệu");
                return RedirectToAction(nameof(Index));
            }
            return View(data);
        }
        [HttpPost]
        [AppAuthorize(AuthConst.Role.UPDATE)]
        public async Task<IActionResult> UpdateRole(RoleEditVM model)
        {
            if (!ModelState.IsValid)
            {
                SetErrorMesg("Đã xãy ra lỗi", true);
                return RedirectToAction(nameof(Index));
            }
            var role = await _repo.FindAsync<Role>(model.Id);
            var curPermisssionIds = _repo
                                .GetAll<RolePermission>(where: s => s.RoleId == role.Id)
                                .ToList();
            if (role == null)
            {
                SetErrorMesg("Không tìm thấy dữ liệu");
                return RedirectToAction(nameof(Index));
            }

            // danh sách permission bị xóa khỏi role
            var deletedPermissionIds = model.DeletedPermissionIds.IsNullOrEmpty() ? null : model.DeletedPermissionIds.Split(',').Select(i => Convert.ToInt32(i));
            // danh sách permission được thêm vào role
            var addedPermissionIds = model.AddedPermissionIds.IsNullOrEmpty() ? null : model.AddedPermissionIds.Split(',').Select(i => Convert.ToInt32(i)).OrderBy(i => i);
            // danh sách permission hiện tại
            var rolePermissionIds = curPermisssionIds
                                .Where(x => deletedPermissionIds != null && deletedPermissionIds.Contains(x.MStPermissionId))
                                .Select(x => x.Id)
                                .OrderBy(x => x);
            // nếu xóa hết permission mà không thêm mới thì không cho thêm
            if ((addedPermissionIds == null || !addedPermissionIds.Any()) && deletedPermissionIds != null && rolePermissionIds.SequenceEqual(deletedPermissionIds))
            {
                SetErrorMesg("Quyền không được để trống");
                return RedirectToAction(nameof(UpdateRole), new { id = model.Id });
            }

            if (deletedPermissionIds != null && deletedPermissionIds.Any())
            {
                await _repo.HardDeleteAsync<RolePermission>(rolePermissionIds);
            }

            if (addedPermissionIds != null && addedPermissionIds.Any())
            {
                var addedRolePermisson = new List<RolePermission>();
                foreach (var item in addedPermissionIds)
                {
                    addedRolePermisson.Add(new RolePermission
                    {
                        RoleId = role.Id,
                        MStPermissionId = item
                    });
                }
                await _repo.AddAsync(addedRolePermisson);
            }
            role.RoleName = model.RoleName;
            role.Description = model.Description;
            await _repo.UpdateAsync(role);
            SetSuccessMesg($"Cập nhật vai trò [{role.RoleName}] thành công");
            return RedirectToAction(nameof(Index));
        }
        [AppAuthorize(AuthConst.Role.DELETE)]
        public async Task<IActionResult> Delete(RoleDeleteVM data)
        {
            if (!ModelState.IsValid)
            {
                SetErrorMesg("Đã xảy ra lỗi", true);
                return RedirectToAction(nameof(Index));
            }

            try
            {
                var users = await _repo.GetAll<User>(where: u => u.IdRole == data.Id).ToListAsync();
                // Cập nhật vai trò mới
                users.ForEach(u => u.IdRole = data.NewId);

                await _repo.BeginTransactionAsync();

                // Cập nhật role mới cho users
                await _repo.UpdateAsync(users);
                // Xóa role cũ
                await _repo.DeleteAsync<User>(data.Id);
                await _repo.CommitTransactionAsync();

                SetSuccessMesg($"Xóa vai trò [{data.Name}] thành công");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Rollback
                await _repo.RollbackTransactionAsync();

                SetErrorMesg("Đã xảy ra lỗi");
                return RedirectToAction(nameof(Delete), new { id = data.Id });
            }
        }
    }
}
