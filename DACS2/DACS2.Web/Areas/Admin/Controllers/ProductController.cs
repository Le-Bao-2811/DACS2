using AutoMapper;
using DACS2.Data.Entities;
using DACS2.Data.Reponsitory;
using DACS2.Share.Consts;
using DACS2.Share.Extensions;
using DACS2.Web.Areas.Admin.ViewModel.Product;
using DACS2.Web.Common;
using DACS2.Web.WebConfig;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace DACS2.Web.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        public readonly IMapper _mapper;
        protected readonly IWebHostEnvironment Host;
        public ProductController(BaseReponsitory _repo, IMapper mapper, IWebHostEnvironment host) : base(_repo)
        {
            _mapper = mapper;
            Host = host;
        }
        string UploadImgAndReturnPath(IFormFile file, string childFolder = "/img/", bool saveInWwwRoot = true)
        {
            var y = Host.WebRootPath;
            var root = saveInWwwRoot ? Host.WebRootPath : Host.ContentRootPath;
            var filename = Path.GetFileNameWithoutExtension(file.FileName)
                            + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss-fff")
                            + Path.GetExtension(file.FileName);
            if (!Directory.Exists(root + childFolder))
            {
                Directory.CreateDirectory(root + childFolder);
            }
            var relativePath = childFolder + filename;
            var path = root + relativePath;
            var x = new FileStream(path, FileMode.Create);
            file.CopyTo(x);
            x.Dispose();
            GC.Collect();
            return relativePath;
        }
        [AppAuthorize(AuthConst.Product.VIEW_LIST)]
        public async Task<IActionResult> Index(int page = 1, int size = 10)
        {
            var data = await _repo.GetAll<Product, ListProductVM>(MapperConfig.ProductIndexConf)
                .ToPagedListAsync(page, size);
            return View(data);
        }
        public async Task<IActionResult> IndexListAmout(int page = 1, int size = 10)
        {
            var data = await _repo.GetAll<Product, ListProductVM>(MapperConfig.ProductIndexConf).Where(x=>x.Amount<20)
                .ToPagedListAsync(page, size);
            return View(data);
        }
        [AppAuthorize(AuthConst.Product.CREATE)]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AppAuthorize(AuthConst.Product.CREATE)]
        public async Task<IActionResult> Create(AddProductVM model)
        {
            Product dataproduct = new Product();
            _mapper.Map<AddProductVM, Product>(model, dataproduct);
            dataproduct.Amount = 0;
            foreach(var amount in model.Amountdesign)
            {
                dataproduct.Amount += amount;
            }
            dataproduct.slug = model.ProductName.Slugify();
            dataproduct.Sold = 0;

            if (model.ImageP != null)
            {
                string image = UploadImgAndReturnPath(model.ImageP, "/img/products/");
                image = image.Split('/').Last();
                dataproduct.pathImgP = image;
            }


            //thêm size
            List<Size> sizes = new List<Size>();
            foreach (var size in model.Size)
            {
                Size data1 = new Size();
                data1.SizeName = size;
                sizes.Add(data1);
            }
            // thêm màu
            List<Color> colors = new List<Color>();
            dataproduct.Amount = 0;
            for (int i = 0; i < model.Color.Count(); i++)
            {
                Color data2 = new Color();
                data2.ColorName = model.Color[i];
                data2.Amount = model.Amountdesign[i];
                colors.Add(data2);

                dataproduct.Amount += model.Amountdesign[i];
            }
            // thêm hình ảnh
            List<Image> images = new List<Image>();
            foreach(var item in model.Image)
            {
                Image data3 = new Image();
                if (model.Image != null)
                {
                    string image = UploadImgAndReturnPath(item, "/img/products/");
                    image = image.Split('/').Last();
                    data3.pathImage = image;
                }
                images.Add(data3);
            }

          
            dataproduct.images = images;
            dataproduct.sizes = sizes;
            dataproduct.colors=colors;
            await _repo.AddAsync<Product>(dataproduct);
            // cap nhật bản categoryproduct
            var data = await _repo.FindAsync<CategoryProduct>(dataproduct.IdProductCategory);
            data.SoLuong += 1;
            await _repo.UpdateAsync(data);

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            var product = await _repo.GetOneAsync<Product, DetailsProductVM>(id, p => new DetailsProductVM
            {
                Id = p.Id,
                Description = p.Description,
                ImportPrice = p.ImportPrice,
                pathImgP = p.pathImgP,
                Price = p.Price,
                ProductName = p.ProductName,
                Unit = p.Unit,
                IdProductCategory=p.IdProductCategory,
                IdSuplier=p.IdSuplier
            });
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Update(DetailsProductVM model)
        {
            if (!ModelState.IsValid)
            {
                var data = await _repo.FindAsync<Product>(model.Id);
                if (model.Description == null)
                {
                    model.Description=data.Description;
                }
                _mapper.Map<DetailsProductVM, Product>(model, data);
                if (model.Image != null)
                {
                    string image = UploadImgAndReturnPath(model.Image, "/img/products/");
                    image = image.Split('/').Last();
                    data.pathImgP = image;
                }
                await _repo.UpdateAsync(data);
                SetSuccessMesg("Cập nhật sản phẩm thành công");
                return RedirectToAction("Index");
            }
            SetErrorMesg("Cập nhật sản phẩm thất bại");
            return View(model);
        }
        [AppAuthorize(AuthConst.Product.DELETE)]
        public async Task<IActionResult> Delete (int id)
        {
            try
            {
                var data = await _repo.FindAsync<Product>(id);
                var cate = await _repo.FindAsync<CategoryProduct>(data.IdProductCategory);
                await _repo.DeleteAsync(data);
                cate.SoLuong -= 1;
                await _repo.UpdateAsync(cate);
                SetSuccessMesg("Xóa sản phẩm thành công");
                return RedirectToAction("Index");
            }catch (Exception ex)
            {
                return Ok(false);
            }
        }
        public async Task<IActionResult> DeleteImage(int id)
        {
            var data=await _repo.FindAsync<Image>(id);
            await _repo.DeleteAsync(data);
            return Ok(true);
        }
        public async Task<IActionResult> UpdateAmout(int id)
        {
            var data = await _repo.GetAll<Color, UpdateAmount>(MapperConfig.UpdateAmountIndexConf).Where(x => x.IdProduct == id).ToListAsync();
            return View(data);
        }
        public async Task<IActionResult>_UpdateAmount(int id)
        {
            var data = await _repo.GetOneAsync<Color,UpdateAmount>(id, u => new UpdateAmount
            {
                Id = u.Id,
                Amount = u.Amount,
                ColorName = u.ColorName,
                IdProduct=u.IdProduct
            });
            return PartialView(data);
        }
        [HttpPost]
        public async Task<IActionResult> _UpdateAmount(UpdateAmount model)
        {
            var data = await _repo.FindAsync<Color>(model.Id);
            var tong=data.Amount + model.Amount;
            _mapper.Map<UpdateAmount, Color>(model, data);
            data.Amount = tong;
            await _repo.UpdateAsync(data);
            var product=await _repo.FindAsync<Product>(model.IdProduct);
            product.Amount += model.Amount;
            await _repo.UpdateAsync(product);
            return Ok(true);

        }
    }
}
