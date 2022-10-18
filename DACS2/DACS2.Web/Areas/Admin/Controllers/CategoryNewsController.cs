using AutoMapper;
using DACS2.Data.Entities;
using DACS2.Data.Reponsitory;
using DACS2.Share.Consts;
using DACS2.Web.Areas.Admin.ViewModel.NewsCategory;
using DACS2.Web.Common;
using DACS2.Web.WebConfig;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace DACS2.Web.Areas.Admin.Controllers
{
    public class CategoryNewsController : BaseController
    {
        IMapper _mapper;
        public CategoryNewsController(BaseReponsitory _repo, IMapper mapper) : base(_repo)
        {
            _mapper = mapper;
        }
        [AppAuthorize(AuthConst.CategoryNews.VIEW_LIST)]
        public IActionResult Index(int page = 1, int size = 10)
        {
            var data = _repo.GetAll<CategoryNews, ListCategoryNewsVM>(MapperConfig.CategoryIndexConf)
                        .ToPagedList(page, size);
            return View(data);
        }
        [AppAuthorize(AuthConst.CategoryNews.CREATE)]
        public IActionResult _Create() => PartialView();
        [HttpPost]
        public async Task<IActionResult> _Create(AddorUpdateCategoryNewsVM model)
        {
            var data = _mapper.Map<CategoryNews>(model);
            await _repo.AddAsync(data);
            SetSuccessMesg("Thêm thể loại tin tức thành công");
            return Ok(true);
        }
        [AppAuthorize(AuthConst.CategoryNews.UPDATE)]
        public async Task<IActionResult> _Update(int id)
        {
            try
            {
                var data = await _repo.GetOneAsync<CategoryNews, AddorUpdateCategoryNewsVM>(id, cate => new AddorUpdateCategoryNewsVM
                {
                    Id = cate.Id,
                    //ProductNewsName = cate.NewsName,
                });
                return PartialView(data);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }

        }
        [HttpPost]
        [AppAuthorize(AuthConst.CategoryNews.UPDATE)]
        public async Task<IActionResult> _Update(AddorUpdateCategoryNewsVM model)
        {
            var data = await _repo.FindAsync<CategoryNews>(model.Id);
            if (data == null)
            {
                SetErrorMesg("Không tìm thấy dữ liệu");
                return Ok(false);
            }
            else
            {
                _mapper.Map<AddorUpdateCategoryNewsVM, CategoryNews>(model, data);
                data.UpdateAt = DateTime.Now;
                await _repo.UpdateAsync(data);
                SetSuccessMesg("Sửa thể loại tin tức thành công");
                return Ok(true);
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _repo.FindAsync<CategoryNews>(id);
            await _repo.DeleteAsync(data);
            SetSuccessMesg("Xóa thể loại tin tức thành công");
            return RedirectToAction("Index");
        }
    }
}
