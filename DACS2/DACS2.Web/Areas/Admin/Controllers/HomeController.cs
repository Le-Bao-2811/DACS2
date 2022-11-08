using DACS2.Web.Common;
using Microsoft.AspNetCore.Mvc;

namespace DACS2.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AppAuthorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
