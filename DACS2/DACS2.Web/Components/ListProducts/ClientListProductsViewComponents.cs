using DACS2.Data.Entities;
using DACS2.Data.Reponsitory;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace DACS2.Web.Components.ListProducts
{
    public class ClientListProductsViewComponents:ViewComponent
    {
        readonly BaseReponsitory repository;
        public ClientListProductsViewComponents(BaseReponsitory _repository)
        {
            repository = _repository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await repository.GetAll<Product>().ToListAsync();
            return View(data);
        }
    }
}
