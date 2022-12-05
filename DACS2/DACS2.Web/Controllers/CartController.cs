using DACS2.Data.Entities;
using DACS2.Data.Reponsitory;
using DACS2.Share.Consts;
using DACS2.Web.Common;
using DACS2.Web.ViewModels.Cart;
using DACS2.Web.WebConfig;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using X.PagedList;

namespace DACS2.Web.Controllers
{
    public class CartController : ClientBaseController
    {
       
        public CartController(BaseReponsitory repo):base(repo) { }
        public async Task<IActionResult> GetOneProduct(int id)
        {
            var data = await _repo.FindAsync<Product>(id);
            return Ok(data);
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
        [AppAuthorize(AuthConst.Invoice.VIEW_LIST)]
        public IActionResult Shopping()
        {
            return View();
        }
        [AppAuthorize(AuthConst.Invoice.VIEW_LIST)]
        [HttpPost]
        public async Task<IActionResult> Shopping(ShoppingVM model)
        {           
            if (model.Name == null)
            {
                SetErrorMesg("Vui lòng điền tên");
                return View();
            }
            if (model.Location == null)
            {
                SetErrorMesg("Vui lòng điền địa chỉ");
                return View();
            }
            if (model.NumberPhone == null)
            {
                SetErrorMesg("Vui lòng điền số điện thoại");
                return View();
            }
            if (model != null)
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
                    dataItem.pathImg = product.pathImgP;
                    var value=item.Value.Split("-");
                    dataItem.Amount = Convert.ToInt32(value[0]);
                    // tính tổng hóa đơn
                    var size = await _repo.FindAsync<Size>(Convert.ToInt32(value[1]));
                    dataItem.Size = size.SizeName;
                    var color = await _repo.FindAsync<Color>(Convert.ToInt32(value[2]));
                    dataItem.Color=color.ColorName;
                    data.Add(dataItem);
                    //trừ sản phẩm 
                    product.Amount -=dataItem.Amount;
                    color.Amount -= dataItem.Amount;
                    await _repo.UpdateAsync<Product>(product);
                    await _repo.UpdateAsync<Color>(color);
                }
                invoice.TotalMoney = model.totalMoney;
                invoice.useVoucher = model.useVoucher;
                invoice.InvoiceDetails = data;
                invoice.StatusId = 1;               
                invoice.CreateBy=Convert.ToInt32(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)); 
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
        public async Task<IActionResult> GetCartByUser(int page=1)
        {
            int id = Convert.ToInt32(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var data = await _repo.GetAll<Invoice, SelectCartByUserVM>(MapperConfig.ListCartByUserIndexConf)
                .Where(x=>x.CreateBy==id).ToPagedListAsync(page, 10);
            return View(data);
        }
    }
}
