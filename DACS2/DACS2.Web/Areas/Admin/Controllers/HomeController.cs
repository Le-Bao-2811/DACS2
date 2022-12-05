using DACS2.Data.Entities;
using DACS2.Data.Reponsitory;
using DACS2.Web.Areas.Admin.ViewModel.Home;
using DACS2.Web.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DACS2.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AppAuthorize]
    public class HomeController : BaseController
    {
        public HomeController(BaseReponsitory reponsitory) : base(reponsitory) { }
        public async Task<IActionResult> Index()
        {
            // số đơn hàng bán được hôm nay
            var donHangBanDuocHomNay = await _repo.GetAll<Invoice>().Where(x=>x.CreateAt>=DateTime.Today).ToListAsync();
            var donHangBanDuoc = await _repo.GetAll<Invoice>().ToListAsync();
            decimal tongdonHangBanDuoc = 0;
            var tongdonHangBanDuocHomNay = 0;
            decimal EarningsToday = 0;
            if (donHangBanDuocHomNay.Count>0 )
            {
                for(int i=0; i<donHangBanDuocHomNay.Count; i++)
                {
                    tongdonHangBanDuocHomNay += 1;
                    EarningsToday += donHangBanDuocHomNay[i].TotalMoney;
                }
            }
            if (donHangBanDuoc.Count > 0)
            {
                for (int i = 0; i < donHangBanDuoc.Count; i++)
                {
                    tongdonHangBanDuoc += donHangBanDuoc[i].TotalMoney;
                }
            }
            StatisticalVM data=new StatisticalVM();
            data.DonHangBanDuocHomNay=tongdonHangBanDuocHomNay;
            data.EarningsToday=EarningsToday;
            data.totalrevenue = tongdonHangBanDuoc;

            return View(data);
        }
    }
}
