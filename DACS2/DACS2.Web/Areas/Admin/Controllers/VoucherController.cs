using AutoMapper;
using DACS2.Data.Entities;
using DACS2.Data.Reponsitory;
using DACS2.Share.Consts;
using DACS2.Web.Areas.Admin.ViewModel.Voucher;
using DACS2.Web.Common;
using DACS2.Web.WebConfig;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace DACS2.Web.Areas.Admin.Controllers
{
    public class VoucherController : BaseController
    {
        public readonly IMapper _mapper;
        public VoucherController(BaseReponsitory _repo,IMapper mapper) : base(_repo) {
            _mapper=mapper;
        }
        [AppAuthorize(AuthConst.Voucher.VIEW_LIST)]
        public async Task<IActionResult> Index(int page=1,int size=10)
        {
            var data = await _repo.GetAll<Voucher, ListVocherVM>(MapperConfig.VoucherIndexConf).ToPagedListAsync(page,size);
            return View(data);
        }
        [AppAuthorize(AuthConst.Voucher.CREATE)]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AppAuthorize(AuthConst.Voucher.CREATE)]
        public async Task<IActionResult> Create(AddorUpdateVocher model)
        {
            if (model.EndDate < DateTime.Now)
            {
                SetErrorMesg("Ngày kết thúc phải lớn hơn thời gian hiện tại");
                return View();
            }
            var data=_mapper.Map<Voucher>(model);
            await _repo.AddAsync(data);
            SetSuccessMesg("Thêm mã giảm giá thành công");
            return RedirectToAction("Index");
        }
        [AppAuthorize(AuthConst.Voucher.UPDATE)]
        public async Task<IActionResult> Update(int id)
        {
            var data = await _repo.GetOneAsync<Voucher, AddorUpdateVocher>(id, r => new AddorUpdateVocher
            {
                Id = r.Id,
                amount = r.amount,
                EndDate = r.EndDate,
                percent = r.percent,
                price = r.price,
                StartDate = r.StartDate,
                VoucherName = r.VoucherName
            });
            return View(data);
        }
        [HttpPost]
        [AppAuthorize(AuthConst.Voucher.UPDATE)]
        public async Task<IActionResult> Update(AddorUpdateVocher model)
        {
            if (model.EndDate < DateTime.Now)
            {
                SetErrorMesg("Ngày kết thúc phải lớn hơn thời gian hiện tại");
                return View();
            }
            var data=await _repo.FindAsync<Voucher>(model.Id);
            _mapper.Map<AddorUpdateVocher, Voucher>(model, data);
            await _repo.UpdateAsync(data);
            SetSuccessMesg("Sửa thành công");
            return RedirectToAction("Index");
        }
        public async Task<IActionResult>Delete(int id)
        {
            var data=await _repo.FindAsync<Voucher>(id);
            await _repo.DeleteAsync(data);
            SetErrorMesg("Xóa mã giảm giá thành công");
            return RedirectToAction("Index");
        }
    }
}
