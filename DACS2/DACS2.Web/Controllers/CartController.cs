using DACS2.Data.Entities;
using DACS2.Data.Reponsitory;
using DACS2.Web.ViewModels.Cart;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

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
        public IActionResult Shopping(ShoppingVM model)
        {
            if(model != null)
            {
                Invoice invoice = new Invoice();
                invoice.NameCustomer = model.Name;
                invoice.Address = model.Location;
                invoice.NumberPhone=model.NumberPhone;
                var cookieList = Request.Cookies.Where(x => x.Key.Contains("products"))
                .ToList();
                foreach(var item in cookieList)
                {
                    int currentID = Convert.ToInt32(item.Key.Replace("products_", ""));
                    var value=item.Value;
                }
            }    
            return Ok();
        }
        public async Task<IActionResult> AddVoucher(string voucher)
        {
            var data= await _repo.GetOneAsync<Voucher>(x=>x.VoucherName==voucher);
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return Ok(false);   
            }
        }
    }
}
