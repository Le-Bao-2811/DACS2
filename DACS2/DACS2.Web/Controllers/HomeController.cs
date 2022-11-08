using DACS2.Data.Entities;
using DACS2.Data.Reponsitory;
using DACS2.Web.Models;
using DACS2.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DACS2.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BaseReponsitory _repo;
        public HomeController(ILogger<HomeController> logger,BaseReponsitory repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> DeltailsProducts(int id)
        {
            var data = await _repo.GetOneAsync<Product, DeltalProductVM>(id, p => new DeltalProductVM
            {
                Id = p.Id,
                Amount = p.Amount,
                Description = p.Description,
                pathImgP=p.pathImgP,
                Price = p.Price,
                ProductName = p.ProductName,
                slug = p.slug,
                Sold = p.Sold,
                Suppler=p.supplier.SupplierName,
            });
            return View(data);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}