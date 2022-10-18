using DACS2.Data.Entities;
using DACS2.Data.Reponsitory;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace DACS2.Web.Areas.Admin.Components.ListCategoryNews
{
    public class ListNewCategoryViewComponents:ViewComponent
    {
        readonly BaseReponsitory repository;
        public ListNewCategoryViewComponents(BaseReponsitory _repository)
        {
            repository = _repository;
        }
        public async Task<IViewComponentResult> InvokeAsync(int? selected)
        {
            var data = await repository.GetAll<CategoryNews>().ToListAsync();
            if(selected != null)
            {
                ViewBag.selected=selected;
            }
            return View(data);
        }
    }
}
