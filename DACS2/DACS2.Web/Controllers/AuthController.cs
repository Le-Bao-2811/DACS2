using AutoMapper;
using DACS2.Data.Entities;
using DACS2.Data.Reponsitory;
using DACS2.Web.Areas.Admin.ViewModel.Account;
using DACS2.Web.ViewModels.Auth;
using DACS2.Web.WebConfig.Const;
using DACS2.Web.WebConfig;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DACS2.Web.Controllers
{
    public class AuthController : ClientBaseController
    {
        protected readonly IMapper _mapper;
        public AuthController(BaseReponsitory repo,IMapper mapper) :base(repo) { 
            _mapper = mapper;
        }

        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(ClientSignUpVM model)
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

            try
            {
                var hashResult = HashHMACSHA512(model.Password);
                model.PasswordHash = hashResult.Value;
                model.PasswordSalt = hashResult.Key;
                model.IdRole = 2;
                var user = _mapper.Map<User>(model);
                await _repo.AddAsync(user);
                SetSuccessMesg($"Đăng kí tài khoản thành công");
                return RedirectToAction("Index","Home");
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
        public async Task<IActionResult> Login(ClientLoginVM model)
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
            SetSuccessMesg("Đăng nhập thành công");
            return RedirectToAction(nameof(Index), "Home");
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(AppConst.COOKIES_AUTH);
            SetSuccessMesg("Đã đăng xuất");
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}
