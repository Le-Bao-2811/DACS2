using DACS2.Data.Entities;
using DACS2.Data.Reponsitory;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace DACS2.Web.Components.ListImage
{
    public class ListImageViewComponents:ViewComponent
    {
        readonly BaseReponsitory repository;
        public ListImageViewComponents(BaseReponsitory _repository)
        {
            repository = _repository;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var data = await repository.GetAll<Image>().Where(x=>x.IdProduct==id).ToListAsync();
            return View(data);
        }
    }
}
