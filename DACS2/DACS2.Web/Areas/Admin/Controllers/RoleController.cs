using Microsoft.AspNetCore.Mvc;

namespace DACS2.Web.Areas.Admin.Controllers
{
    public class RoleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
