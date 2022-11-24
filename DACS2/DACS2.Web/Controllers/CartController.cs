using DACS2.Data.Entities;
using DACS2.Data.Reponsitory;
using DACS2.Web.ViewModels.Cart;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Security.Claims;

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
                        ProductName = p.ProductName,                        
                    });
                    var color = await _repo.FindAsync<Color>(product.Id);
                    var size = await _repo.FindAsync<Size>(product.Id);
                    product.color=color.ColorName;
                    product.size=size.SizeName;
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
        public async Task<IActionResult> Shopping(ShoppingVM model)
        {
            if(model != null)
            {
                Invoice invoice = new Invoice();
                invoice.NameCustomer = model.Name;
                invoice.Address = model.Location;
                invoice.NumberPhone=model.NumberPhone;
                invoice.TotalMoney = 0;
                var cookieList = Request.Cookies.Where(x => x.Key.Contains("products"))
                .ToList();
                List<InvoiceDetails> data = new List<InvoiceDetails>();
                foreach(var item in cookieList)
                {
                    InvoiceDetails dataItem = new InvoiceDetails();
                    int currentID = Convert.ToInt32(item.Key.Replace("products_", ""));
                    //get tên sản phẩm
                    var product=await _repo.FindAsync<Product>(currentID);
                    dataItem.ProductName = product.ProductName;
                    dataItem.Money = product.Price;
                    var value=item.Value.Split("-");
                    dataItem.Amount = Convert.ToInt32(value[0]);
                    // tính tổng hóa đơn
                    dataItem.Size = value[1];
                    var color = await _repo.FindAsync<Color>(Convert.ToInt32(value[2]));
                    dataItem.Color=color.ColorName;
                    data.Add(dataItem);
                    //trừ sản phẩm 
                    product.Amount -=dataItem.Amount;
                    await _repo.UpdateAsync<Product>(product);
                }
                invoice.TotalMoney = model.totalMoney;
                invoice.useVoucher = model.useVoucher;
                invoice.InvoiceDetails = data;
                invoice.StatusId = 1;
                invoice.CreateBy=Convert.ToInt32(ClaimTypes.NameIdentifier);
                await _repo.AddAsync<Invoice>(invoice);
                TempData["Messenger"] = "Đặt hàng thành công";
                return RedirectToAction("Index","Home");
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
