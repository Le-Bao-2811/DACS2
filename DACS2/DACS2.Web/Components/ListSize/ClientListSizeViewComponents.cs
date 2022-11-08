using DACS2.Data.Entities;
using DACS2.Data.Reponsitory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using X.PagedList;

namespace DACS2.Web.Components.ListSize
{
    public class ClientListSizeViewComponents :ViewComponent
    {
        readonly BaseReponsitory repository;
        public ClientListSizeViewComponents(BaseReponsitory _repository)
        {
            repository = _repository;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var data = await repository.GetAll<Size>().Where(x=>x.IdProduct==id).ToListAsync();
            return View(data);
        }
    }
}
