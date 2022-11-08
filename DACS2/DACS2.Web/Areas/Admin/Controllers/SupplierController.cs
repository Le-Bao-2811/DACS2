using AutoMapper;
using DACS2.Data.Entities;
using DACS2.Data.Reponsitory;
using DACS2.Share.Consts;
using DACS2.Web.Areas.Admin.ViewModel.Supplier;
using DACS2.Web.Common;
using DACS2.Web.WebConfig;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace DACS2.Web.Areas.Admin.Controllers
{
    public class SupplierController : BaseController
    {
        public readonly IMapper _mapper;
        public SupplierController(BaseReponsitory _repo,IMapper mapper):base(_repo) { 
            _mapper = mapper;
        }
        [AppAuthorize(AuthConst.Supplier.VIEW_LIST)]
        public async Task<IActionResult> Index(int page=1,int size=10)
        {
            var data = await _repo.GetAll<Supplier, ListSupplierVM>(MapperConfig.SupplierIndexConf).ToPagedListAsync(page, size);
            return View(data);               
        }
        [AppAuthorize(AuthConst.Supplier.CREATE)]
        public IActionResult _Create() 
        {
            return PartialView();
        }
        [HttpPost]
        [AppAuthorize(AuthConst.Supplier.CREATE)]
        public async Task<IActionResult> _Create(AddorUpdateSupplerVM model)
        {
            var data=_mapper.Map<Supplier>(model);
            await _repo.AddAsync(data);
            SetSuccessMesg("Thêm thành cung cấp thành công");
            return Ok(true);
        }
        [AppAuthorize(AuthConst.Supplier.UPDATE)]
        public async Task<IActionResult>_Update(int id)
        {
            var data = await _repo.GetOneAsync<Supplier, AddorUpdateSupplerVM>(id, s => new AddorUpdateSupplerVM
            {
                Id = s.Id,
                SupplierName = s.SupplierName,
            });
            return PartialView(data);
        }
        [HttpPost]
        [AppAuthorize(AuthConst.Supplier.UPDATE)]
        public async Task<IActionResult>_Update(AddorUpdateSupplerVM model)
        {
            var data = await _repo.FindAsync<Supplier>(model.Id);
            _mapper.Map<AddorUpdateSupplerVM, Supplier>(model, data);
            await _repo.UpdateAsync(data);
            SetSuccessMesg("Sửa nhà cung cấp thành công");
            return Ok(true);
        }
        [AppAuthorize(AuthConst.Supplier.DELETE)]
        public async Task<IActionResult>Delete(int id)
        {
            var data=await _repo.FindAsync<Supplier>(id);
            await _repo.DeleteAsync(data);
            SetSuccessMesg("Xóa nhà cung cấp thành công");
            return RedirectToAction("Index");
        }
    }
}
