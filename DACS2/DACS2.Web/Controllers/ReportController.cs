using AutoMapper;
using DACS2.Data.Entities;
using DACS2.Data.Reponsitory;
using DACS2.Web.ViewModels.Report;
using Microsoft.AspNetCore.Mvc;

namespace DACS2.Web.Controllers
{
    public class ReportController : ClientBaseController
    {
        private readonly IMapper _mapper;
        public ReportController(BaseReponsitory repo,IMapper mapper):base(repo) { 
            _mapper = mapper;
        }
        
        public IActionResult AddReport()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddReport(AddReportVM model)
        {
            var data= _mapper.Map<Report>(model);
            data.Status=false;
            await _repo.AddAsync(data);
            SetSuccessMesg("Cảm ơn bạn đã phản hồi");
            return RedirectToAction("Index","Home");
        }
    }
}
