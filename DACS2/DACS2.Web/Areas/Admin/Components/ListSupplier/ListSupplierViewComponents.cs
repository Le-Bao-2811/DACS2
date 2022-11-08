using DACS2.Data.Entities;
using DACS2.Data.Reponsitory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DACS2.Web.Areas.Admin.Components.ListSupplier
{
    public class ListSupplierViewComponents:ViewComponent
    {
        readonly BaseReponsitory repository;
        public ListSupplierViewComponents(BaseReponsitory _repository)
        {
            repository = _repository;
        }
        public async Task<IViewComponentResult> InvokeAsync(int? selected)
        {
            var data = await repository.GetAll<Supplier>().ToListAsync();
            if (selected != null)
            {
                ViewBag.selected = selected;
            }
            return View(data);
        }
    }
}
