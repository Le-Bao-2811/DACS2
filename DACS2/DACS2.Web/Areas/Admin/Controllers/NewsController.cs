using AutoMapper;
using DACS2.Data.Entities;
using DACS2.Data.Reponsitory;
using DACS2.Share.Consts;
using DACS2.Web.Areas.Admin.ViewModel.News;
using DACS2.Web.Common;
using DACS2.Web.WebConfig;
using Microsoft.AspNetCore.Mvc;
using System;
using X.PagedList;

namespace DACS2.Web.Areas.Admin.Controllers
{
    public class NewsController : BaseController
    {
        public readonly IMapper _mapper;
        protected readonly IWebHostEnvironment Host;
        public NewsController(BaseReponsitory _repo,IMapper mapper, IWebHostEnvironment host) : base(_repo)
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
        [AppAuthorize(AuthConst.News.VIEW_LIST)]
        public IActionResult Index(int page=1,int size=10)
        {
            var data = _repo.GetAll<News, ListNewsVM>(MapperConfig.NewsIndexConf).ToPagedList(page,size);
            return View(data);
        }
        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddorUpdateNewsVM model)
        {
            if(model == null)
            {
                SetErrorMesg("Không có dữ liệu");
                return View();
            }
            else
            {
                var data = _mapper.Map<News>(model);
                if(model.Image!=null)
                {
                    string image = UploadImgAndReturnPath(model.Image, "/img/news/");
                    image = image.Split('/').Last();
                    data.pathImg=image;
                }              
                await _repo.AddAsync(data);
                return RedirectToAction("Index");
            }
        }
        [AppAuthorize(AuthConst.News.UPDATE)]
        public async Task<IActionResult> Update(int id)
        {
            var data = await _repo.GetOneAsync<News, AddorUpdateNewsVM>(id, r => new AddorUpdateNewsVM
            {
                Id = r.Id,
                Content = r.Content,
                IdCategoryNew = r.IdCategoryNew,
                Title = r.Title,
                pathImg = r.pathImg
            });
            return View(data);
        }
        [HttpPost]
        [AppAuthorize(AuthConst.News.UPDATE)]
        public async Task<IActionResult>Update(AddorUpdateNewsVM model)
        {
            var data = await _repo.FindAsync<News>(model.Id);
            if (data == null)
            {
                SetErrorMesg("Không có dữ liệu");
                return View();
            }
            else
            {
                if (model.Image != null)
                {
                    string image = UploadImgAndReturnPath(model.Image, "/img/news/");
                    image = image.Split('/').Last();
                    model.pathImg = image;
                }
                _mapper.Map<AddorUpdateNewsVM,News>(model,data);
                await _repo.UpdateAsync<News>(data);
                SetSuccessMesg("Sửa tin tức thành công");
                return RedirectToAction("Index");
            }
        }
        [AppAuthorize(AuthConst.News.DELETE)]
        public async Task<IActionResult>Delete(int id)
        {
            var data = await _repo.FindAsync<News>(id);
            await _repo.DeleteAsync(data);
            SetSuccessMesg("Xóa thanh công");
            return RedirectToAction("Index");
        }
    }
}
