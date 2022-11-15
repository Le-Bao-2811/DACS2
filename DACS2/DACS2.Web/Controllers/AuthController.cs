using AutoMapper;
using DACS2.Data.Entities;
using DACS2.Data.Reponsitory;
using DACS2.Web.Areas.Admin.ViewModel.Account;
using DACS2.Web.ViewModels.Auth;
using Microsoft.AspNetCore.Mvc;

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
    }
}
