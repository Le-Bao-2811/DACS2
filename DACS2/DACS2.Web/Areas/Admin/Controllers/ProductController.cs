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
                Size data = new Size();
                data.SizeName = size;
                sizes.Add(data);
            }
            // thêm màu
            List<Color> colors = new List<Color>();
            foreach (var size in model.Color)
            {
                Color data = new Color();
                data.ColorName = size;
                colors.Add(data);
            }
            // thêm hình ảnh
            List<Image> images = new List<Image>();
            foreach(var item in model.Image)
            {
                Image data = new Image();
                if (model.Image != null)
                {
                    string image = UploadImgAndReturnPath(item, "/img/products/");
                    image = image.Split('/').Last();
                    data.pathImage = image;
                }
                images.Add(data);
            }

            // cập nhật số lượng
            var categoryProduct = await _repo.FindAsync<CategoryProduct>(model.IdProductCategory);

            // thêm kiểu dáng
            List<Designs> designs = new List<Designs>();
            for (int i=0;i<model.Design.Count();i++)
            {
                Designs data = new Designs();
                data.DesignsName = model.Design[i];
                data.Amount = model.Amountdesign[i];               
                designs.Add(data);

                categoryProduct.SoLuong += model.Amountdesign[i];
            }
            await _repo.UpdateAsync(categoryProduct);

          
            dataproduct.designs = designs;
            dataproduct.images = images;
            dataproduct.sizes = sizes;
            dataproduct.colors=colors;
            await _repo.AddAsync<Product>(dataproduct);
            return RedirectToAction("Index");
        }
        [AppAuthorize(AuthConst.Product.DELETE)]
        public async Task<IActionResult> Delete (int id)
        {
            try
            {
                var data = await _repo.FindAsync<Product>(id);
                await _repo.DeleteAsync(data);
                SetSuccessMesg("Xóa sản phẩm thành công");
                return RedirectToAction("Index");
            }catch (Exception ex)
            {
                return Ok(false);
            }
        }
    }
}
