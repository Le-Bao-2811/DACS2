using DACS2.Data.Entities;
using DACS2.Data.Reponsitory;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
namespace DACS2.Web.Areas.Admin.Components.ListRole
{
    public class ListRoleViewComponents :ViewComponent
    {
        readonly BaseReponsitory repository;
        public ListRoleViewComponents(BaseReponsitory _repository)
        {
            repository = _repository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await repository.GetAll<Role>().ToListAsync();
            return View(data);
        }
    }
}
