using AutoMapper;
using DACS2.Data.Entities;
using DACS2.Data.Reponsitory;
using DACS2.Share.Consts;
using DACS2.Web.Areas.Admin.ViewModel.CategoryProduct;
using DACS2.Web.Common;
using DACS2.Web.WebConfig;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace DACS2.Web.Areas.Admin.Controllers
{
    public class CategoryProductController : BaseController
    {
        public readonly IMapper _mapper;
        protected readonly IWebHostEnvironment Host;
        public CategoryProductController(BaseReponsitory _repo,IMapper mapper, IWebHostEnvironment _host) : base(_repo) { 
            _mapper=mapper;
            Host = _host;
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

        [AppAuthorize(AuthConst.CategoryProduct.VIEW_LIST)]
        public async Task<IActionResult> Index(int page=1,int size=10)
        {
            var data = await _repo.GetAll<CategoryProduct, ListCategoryProductVM>(MapperConfig.CategoryProductIndexConf).ToPagedListAsync(page, size);
            return View(data);
        }
        [AppAuthorize(AuthConst.CategoryProduct.CREATE)]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AppAuthorize(AuthConst.CategoryProduct.CREATE)]
        public async Task<IActionResult> Create(AddorUpdateCtProductVM model) {            
            var data=_mapper.Map<CategoryProduct>(model);
            if (model.Image != null)
            {
                string image = UploadImgAndReturnPath(model.Image, "/img/categoryProduct/");
                image = image.Split('/').Last();
                data.pathImg = image;
            }
            await _repo.AddAsync(data);
            SetSuccessMesg("Thêm thể loại sản phẩm thành công");
            return RedirectToAction("Index");
        }
        [AppAuthorize(AuthConst.CategoryProduct.UPDATE)]
        public async Task<IActionResult> _Update(int id)
        {
            var data = await _repo.GetOneAsync<CategoryProduct, AddorUpdateCtProductVM>(id, c => new AddorUpdateCtProductVM
            {
                CategoryName = c.CategoryName,
                Id = c.Id
            });
            return PartialView(data);
        }
        [HttpPost]
        [AppAuthorize(AuthConst.CategoryProduct.UPDATE)]
        public async Task<IActionResult> _Update(AddorUpdateCtProductVM model)
        {
            var data = await _repo.FindAsync<CategoryProduct>(model.Id);
            _mapper.Map<AddorUpdateCtProductVM,CategoryProduct>(model, data);
            await _repo.UpdateAsync(data);
            SetSuccessMesg("Sửa thể loại sản phẩm thành công");
            return Ok(true);
        }
        [AppAuthorize(AuthConst.CategoryProduct.DELETE)]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _repo.FindAsync<CategoryProduct>(id);
            await _repo.DeleteAsync(data);
            SetSuccessMesg("Xóa thể loại sản phẩm thành công");
            return RedirectToAction("Index");
        }
    }
}
