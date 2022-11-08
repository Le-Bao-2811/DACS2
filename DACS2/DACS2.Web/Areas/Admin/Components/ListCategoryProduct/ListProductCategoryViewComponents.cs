using DACS2.Data.Entities;
using DACS2.Data.Reponsitory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DACS2.Web.Areas.Admin.Components.ListCategoryProduct
{
    public class ListProductCategoryViewComponents:ViewComponent
    {
        readonly BaseReponsitory repository;
        public ListProductCategoryViewComponents(BaseReponsitory _repository)
        {
            repository = _repository;
        }
        public async Task<IViewComponentResult> InvokeAsync(int? selected)
        {
            var data = await repository.GetAll<CategoryProduct>().ToListAsync();
            if (selected != null)
            {
                ViewBag.selected = selected;
            }
            return View(data);
        }
    }
}
