using DACS2.Data.Entities;
using DACS2.Data.Reponsitory;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using X.PagedList;

namespace DACS2.Web.Components.ListDesign
{
    public class ClientListDesignsViewComponents:ViewComponent
    {
        readonly BaseReponsitory repository;
        public ClientListDesignsViewComponents(BaseReponsitory _repository)
        {
            repository = _repository;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var data = await repository.GetAll<Designs>().Where(x => x.IdProduct == id).ToListAsync();
            return View(data);
        }
    }
}
