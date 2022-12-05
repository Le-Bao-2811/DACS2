using DACS2.Data.Entities;
using DACS2.Data.Reponsitory;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace DACS2.Web.Areas.Admin.Components.ListImageAdmin
{
    public class ListImageAdminViewComponents : ViewComponent
    {
        readonly BaseReponsitory repository;
        public ListImageAdminViewComponents(BaseReponsitory _repository)
        {
            repository = _repository;
        }
        public async Task<IViewComponentResult> InvokeAsync(int? selected)
        {
            var data = await repository.GetAll<Image>().Where(x => x.IdProduct == selected).ToListAsync();

            return View(data);
        }
    }
}
