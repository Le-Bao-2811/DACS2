using DACS2.Data.Entities;
using DACS2.Data.Reponsitory;
using DACS2.Web.ViewModels.Cart;
using Microsoft.AspNetCore.Mvc;

namespace DACS2.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly BaseReponsitory _repo;
        public CartController(BaseReponsitory repo)
        {
            _repo = repo;
        }
        public async Task<IActionResult> GetProduct(List<int> listid)
        {
            if (listid.Count == 0)
            {
                return Ok();
            }
            else
            {
                List<CartProductVM> data= new List<CartProductVM>();
                foreach(var id in listid)
                {
                    var product = await _repo.GetOneAsync<Product, CartProductVM>(id, p => new CartProductVM
                    {
                        Id = p.Id,
                        pathImgP=p.pathImgP,
                        Price = p.Price,
                        ProductName = p.ProductName
                    });
                    data.Add(product);
                }
                return Ok(data);
            }
        }
        public IActionResult Shopping()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Shopping(CartProductVM model)
        {
            return Ok();
        }
    }
}
