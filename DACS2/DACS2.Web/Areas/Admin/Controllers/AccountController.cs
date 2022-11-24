using AutoMapper;
using DACS2.Data.Entities;
using DACS2.Data.Reponsitory;
using DACS2.Share.Consts;
using DACS2.Share.Extensions;
using DACS2.Web.Areas.Admin.ViewModel.Account;
using DACS2.Web.Common;
using DACS2.Web.WebConfig;
using DACS2.Web.WebConfig.Const;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using System.Security.Claims;
using X.PagedList;

namespace DACS2.Web.Areas.Admin.Controllers
{
    
    public class AccountController : BaseController
    {
        public readonly IMapper _mapper;
        public AccountController(BaseReponsitory _repo, IMapper mapper) : base(_repo)
        {
            _mapper = mapper;
        }
        [AppAuthorize(AuthConst.User.VIEW_LIST)]
        public IActionResult Index(int page = 1, int size = 10)
        {
            var data = _repo.GetAll<User, ListUserVM>(MapperConfig.UserIndexConf)
                .ToPagedList(page, size);
            return View(data);
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpVM model)
        {
            if (!ModelState.IsValid)
            {
                SetErrorMesg("Dữ liệu không hợp lệ vui lòng kiểm tra lại!");
                return View(model);
            }
            model.UserName = model.UserName.ToLower();
            if (await _repo.AnyAsync<User>(x => x.UserName == model.UserName))
            {
                SetErrorMesg("Tên đăng nhập đã tồn tại vui lòng kiểm tra lại!");
                return View(model);
            }

            if (model.IsSubmit == false)
            {
                SetErrorMesg("Bạn chưa đồng ý điều khoản và điều kiện!");
                return View(model);
            }
            try
            {
                var hashResult = HashHMACSHA512(model.Password);
                model.PasswordHash = hashResult.Value;
                model.PasswordSalt = hashResult.Key;
                var user = _mapper.Map<User>(model);
                await _repo.AddAsync(user);
                SetSuccessMesg($"Thêm tài khoản [{user.UserName}] thành công");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            var user = await _repo.GetOneAsync<User, UserDataForApp>
                            (
                                where: x => x.UserName == model.UserName.ToLower(),
                                MapperConfig.LoginConf
                            );
            if (user == null)
            {
                TempData["Mesg"] = "Tài khoản không tồn tại";
                return View();
            }

            //if (user.BlockedTo.HasValue && user.BlockedTo.Value >= DateTime.Now)
            //{
            //    TempData["Mesg"] = $"Tài khoản của bạn bị khóa đến {user.BlockedTo.Value:dd/MM/yyyy HH:mm}";
            //    return View();
            //}
            //if (user.BlockedTo.HasValue && user.BlockedTo.Value <= DateTime.Now)
            //{
            //    var data = await _repo.FindAsync<AppUser>(user.Id);
            //    data.BlockedTo = null;
            //    data.BlockedBy = null;
            //    await _repo.UpdateAsync(data);
            //}

            var pwdHash = this.HashHMACSHA512WithKey(model.Password, user.PasswordSalt);
            if (!pwdHash.SequenceEqual(user.PasswordHash))
            {
                TempData["Mesg"] = "Tên đăng nhập hoặc mật khẩu không chính xác";
                return View();
            }

            var claims = new List<Claim> {
                            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                            new Claim(ClaimTypes.Name, user.UserName),
                            new Claim(ClaimTypes.Email, user.Gmail),
                            new Claim(AppClaimType.PhoneNumber, user.SDT),
                            new Claim(AppClaimType.RoleName, user.RoleName),
                            new Claim(AppClaimType.RoleId, user.RoleId.ToString()),
                            new Claim(AppClaimType.Permissions, user.Permission),
                        };
            var claimsIdentity = new ClaimsIdentity(claims, AppConst.COOKIES_AUTH);
            var principal = new ClaimsPrincipal(claimsIdentity);
            var authenPropeties = new AuthenticationProperties()
            {
                ExpiresUtc = DateTime.UtcNow.AddHours(AppConst.LOGIN_TIMEOUT),
                IsPersistent = model.RemeberMe
            };
            await HttpContext.SignInAsync(AppConst.COOKIES_AUTH, principal, authenPropeties);

            //CreateDirIfNotExist(model.Username);
            //var returnUrl = Request.Query["ReturnUrl"].ToString();
            //if (returnUrl.IsNullOrEmpty())
            //{
            //    return HomePage();
            //}
            return RedirectToAction(nameof(Index), "Account");
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(AppConst.COOKIES_AUTH);
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}
