using DACS2.Data.Entities;
using DACS2.Data.Reponsitory;
using DACS2.Web.ViewModels.News;
using DACS2.Web.WebConfig;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace DACS2.Web.Controllers
{
    public class NewsHomeController : ClientBaseController
    {
        public NewsHomeController(BaseReponsitory reponsitory) : base(reponsitory) { }
        public async Task<IActionResult> Index(int page=1)
        {
            var data = await _repo.GetAll<News, ListNewsClientVM>(MapperConfig.ListClientNewsIndexConf).ToPagedListAsync(page, 10);
            return View(data);
        }
        public async Task<IActionResult> DetailsNews(int id)
        {
            var data = await _repo.GetOneAsync<News, ListNewsClientVM>(id, n => new ListNewsClientVM
            {
                Id = n.Id,
                Content = n.Content,
                pathImg = n.pathImg,
                Title = n.Title
            });
            return View(data);
        }
    }
}
