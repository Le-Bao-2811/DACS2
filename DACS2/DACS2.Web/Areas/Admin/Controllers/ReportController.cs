using AutoMapper;
using DACS2.Data.Entities;
using DACS2.Data.Reponsitory;
using DACS2.Web.Areas.Admin.ViewModel.Report;
using DACS2.Web.WebConfig;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace DACS2.Web.Areas.Admin.Controllers
{
    public class ReportController : BaseController
    {

        public ReportController(BaseReponsitory repo):base(repo) { 
            
        }
        
        public async Task<IActionResult> Index(int page=1)
        {
            var data = await _repo.GetAll<Report, ListReportVM>(MapperConfig.ReportIndexConf).Where(x=>x.Status==false).ToPagedListAsync(page, 10);
            return View(data);
        }
        public async Task<IActionResult> IndexReprtSucset(int page = 1)
        {
            var data = await _repo.GetAll<Report, ListReportVM>(MapperConfig.ReportIndexConf).Where(x => x.Status == true).ToPagedListAsync(page, 10);
            return View(data);
        }
        public async Task<IActionResult> Details(int id)
        {
            var data = await _repo.GetOneAsync<Report, DetailsReportVM>(id,r=>new DetailsReportVM
            {
                FullName = r.FullName,
                NumberPhone = r.NumberPhone,
                ReportContent = r.ReportContent,
                Status = r.Status
            });
            return PartialView(data);
        }
        public async Task<IActionResult> SetStatus(int id)
        {
            var data = await _repo.FindAsync<Report>(id);
            data.Status = true;
            await _repo.UpdateAsync(data);
            return RedirectToAction("Index");
        }
    }
}
