using AutoMapper;
using DACS2.Data.Reponsitory;
using Microsoft.AspNetCore.Mvc;

namespace DACS2.Web.Areas.Admin.Controllers
{
    public class SupplierController : BaseController
    {
        public readonly IMapper _mapper;
        public SupplierController(BaseReponsitory _repo,IMapper mapper):base(_repo) { 
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
