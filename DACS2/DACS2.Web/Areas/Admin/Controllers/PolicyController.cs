using AutoMapper;
using DACS2.Data.Entities;
using DACS2.Data.Reponsitory;
using DACS2.Share.Consts;
using DACS2.Web.Areas.Admin.ViewModel.Policy;
using DACS2.Web.Common;
using DACS2.Web.WebConfig;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace DACS2.Web.Areas.Admin.Controllers
{
    public class PolicyController : BaseController
    {
        public readonly IMapper _mapper;
        public PolicyController(BaseReponsitory _repo,IMapper mapper):base(_repo) {
            _mapper = mapper;
        }
        [AppAuthorize(AuthConst.Policy.VIEW_LIST)]
        public async Task<IActionResult> Index(int page=1,int size=10)
        {
            var data = await _repo.GetAll<Policy, ListPolicyVM>(MapperConfig.PolicyIndexConf).ToPagedListAsync(page,size);
            return View(data);
        }
        [AppAuthorize(AuthConst.Policy.CREATE)]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AppAuthorize(AuthConst.Policy.CREATE)]
        public async Task<IActionResult> Create(AddorUpdatePolicyVM model)
        {
            var data = _mapper.Map<Policy>(model);
            await _repo.AddAsync(data);
            SetSuccessMesg("Thêm chính sách thành công");
            return RedirectToAction("Index");
        }
        [AppAuthorize(AuthConst.Policy.UPDATE)]
        public async Task<IActionResult>Update(int id)
        {
            var data = await _repo.GetOneAsync<Policy, AddorUpdatePolicyVM>(id, p => new AddorUpdatePolicyVM
            {
                Id = p.Id,
                Content = p.Content,
                PolicyName = p.PolicyName,
            });
            return View(data);
        }
        [HttpPost]
        [AppAuthorize(AuthConst.Policy.UPDATE)]
        public async Task<IActionResult>Update(AddorUpdatePolicyVM model)
        {
            var data=await _repo.FindAsync<Policy>(model.Id);
            _mapper.Map<AddorUpdatePolicyVM, Policy>(model, data);
            await _repo.UpdateAsync(data);
            SetSuccessMesg("Sửa chinh sách thành công");
            return RedirectToAction("Index");
        }
        [AppAuthorize(AuthConst.Policy.DELETE)]
        public async Task<IActionResult>Delete(int id)
        {
            var data= await _repo.FindAsync<Policy>(id);
            await _repo.DeleteAsync(data);
            SetSuccessMesg("Xóa chính sách thành công");
            return RedirectToAction("Index");
        }
    }
}
