using DACS2.Data.Entities;
using DACS2.Data.Reponsitory;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace DACS2.Web.Components.ListCategoryProduct
{
    public class ClientCPViewComponents :ViewComponent
    {
        readonly BaseReponsitory repository;
        public ClientCPViewComponents(BaseReponsitory _repository)
        {
            repository = _repository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await repository.GetAll<CategoryProduct>().ToListAsync();
            return View(data);
        }
    }
}
