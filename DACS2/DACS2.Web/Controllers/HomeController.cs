using AutoMapper;
using DACS2.Data.Entities;
using DACS2.Data.Reponsitory;
using DACS2.Share.Extensions;
using DACS2.Web.Models;
using DACS2.Web.ViewModels;
using DACS2.Web.ViewModels.Client;
using DACS2.Web.WebConfig;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using X.PagedList;

namespace DACS2.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BaseReponsitory _repo;
        private readonly IMapper _mapper;
        public HomeController(ILogger<HomeController> logger, BaseReponsitory repo, IMapper mapper)
        {
            _logger = logger;
            _repo = repo;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> AllProduct(string? search, string fillter = "")
        {
            if (search != null)
            {
                search = search.Slugify();
                var data = await _repo.GetAll<Product, ClientListAllProducts>(MapperConfig.ClientListProductsIndexConf).Where(s => s.slug.Contains(search)).ToPagedListAsync(1, 20);
                return View(data);
            }
            if (fillter != "")
            {
                var arrayfillter = fillter.Split("-");
                var to = Convert.ToInt32(arrayfillter[0]);
                var from = Convert.ToInt32(arrayfillter[1]);
                if (from == 0)
                {
                    var data = await _repo.GetAll<Product, ClientListAllProducts>(MapperConfig.ClientListProductsIndexConf).Where(s => s.Price > to).ToPagedListAsync(1, 20);
                    return View(data);
                }
                else
                {
                    var data = await _repo.GetAll<Product, ClientListAllProducts>(MapperConfig.ClientListProductsIndexConf).Where(s => s.Price > to && s.Price < from).ToPagedListAsync(1, 20);
                    return View(data);
                }

            }
            else
            {
                var data = await _repo.GetAll<Product, ClientListAllProducts>(MapperConfig.ClientListProductsIndexConf).ToPagedListAsync(1, 20);
                return View(data);
            }
        }
        public async Task<IActionResult> GetProductByCategory(int id, string fillter = "")
        {
            if (fillter != "")
            {
                var arrayfillter = fillter.Split("-");
                var to = Convert.ToInt32(arrayfillter[0]);
                var from = Convert.ToInt32(arrayfillter[1]);
                if (from == 0)
                {
                    var data = await _repo.GetAll<Product, ClientListAllProducts>(MapperConfig.ClientListProductsIndexConf).Where(s => s.Price > to).Where(x => x.IdProductCategory == id).ToPagedListAsync(1, 20);
                    return View(data);
                }
                else
                {
                    var data = await _repo.GetAll<Product, ClientListAllProducts>(MapperConfig.ClientListProductsIndexConf).Where(s => s.Price > to && s.Price < from).Where(x=>x.IdProductCategory==id).ToPagedListAsync(1, 20);
                    return View(data);
                }

            }
            else
            {
                var data = await _repo.GetAll<Product, ClientListAllProducts>(MapperConfig.ClientListProductsIndexConf).Where(x=>x.IdProductCategory==id).ToPagedListAsync(1, 20);
                return View(data);
            }
        }

        public async Task<IActionResult> DeltailsProducts(int id)
        {
            var data = await _repo.GetOneAsync<Product, DeltalProductVM>(id, p => new DeltalProductVM
            {
                Id = p.Id,
                Amount = p.Amount,
                Description = p.Description,
                pathImgP = p.pathImgP,
                Price = p.Price,
                ProductName = p.ProductName,
                slug = p.slug,
                Sold = p.Sold,
                Suppler = p.supplier.SupplierName,
            });
            return View(data);
        }
        public async Task<IActionResult> DetailPolicy(int id)
        {
            var data=await _repo.FindAsync<Policy>(id);
            return View(data);
        }
    }
}