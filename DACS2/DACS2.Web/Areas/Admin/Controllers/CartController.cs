using AutoMapper;
using DACS2.Data.Entities;
using DACS2.Data.Reponsitory;
using DACS2.Web.Areas.Admin.ViewModel.Cart;
using DACS2.Web.ViewModels.Cart;
using DACS2.Web.WebConfig;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace DACS2.Web.Areas.Admin.Controllers
{
    public class CartController : BaseController
    {
        private readonly IMapper _mapper;
        public CartController(BaseReponsitory repo,IMapper mapper):base(repo) { 
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(int page=1)
        {
            var data = await _repo.GetAll<Invoice, SelectCartVM>(MapperConfig.SelectCartIndexConf)
                .Where(x=>x.Statuscart== "Đang chờ xử lý").ToPagedListAsync(page, 10);
            return View(data);
        }
        public async Task<IActionResult> ListCartStatus2(int page = 1)
        {
            var data = await _repo.GetAll<Invoice, SelectCartVM>(MapperConfig.SelectCartIndexConf)
               .Where(x => x.Statuscart == "Đang lấy hàng").ToPagedListAsync(page, 10);
            return View(data);
        }
        public async Task<IActionResult> ListCartStatus3(int page = 1)
        {
            var data = await _repo.GetAll<Invoice, SelectCartVM>(MapperConfig.SelectCartIndexConf)
               .Where(x => x.Statuscart == "Đang giao hàng").ToPagedListAsync(page, 10);
            return View(data);
        }
        public async Task<IActionResult> ListCartStatus4(int page = 1)
        {
            var data = await _repo.GetAll<Invoice, SelectCartVM>(MapperConfig.SelectCartIndexConf)
               .Where(x => x.Statuscart == "Giao hàng thành công").ToPagedListAsync(page, 10);
            return View(data);
        }
        public async Task<IActionResult> ListCartStatus5(int page = 1)
        {
            var data = await _repo.GetAll<Invoice, SelectCartVM>(MapperConfig.SelectCartIndexConf)
               .Where(x => x.Statuscart == "Giao hàng không thành công").ToPagedListAsync(page, 10);
            return View(data);
        }
        public async Task<IActionResult>DetailInvoice(int id)
        {
            var data = await _repo.GetOneAsync<Invoice, DetailCartVM>(id, r => new DetailCartVM { 
                Id = r.Id,
                Address = r.Address,
                NameCustomer = r.NameCustomer,
                NumberPhone = r.NumberPhone,
                InvoiceDetails = r.InvoiceDetails,
                StatusId = r.StatusId,
                TotalMoney = r.TotalMoney
            });
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> DetailInvoice(DetailCartVM model)
        {
            
            var invoice= await _repo.FindAsync<Invoice>(model.Id);
            _mapper.Map<DetailCartVM,Invoice>(model, invoice);
            await _repo.UpdateAsync(invoice);
            return RedirectToAction("Index");

        }
    }
}
