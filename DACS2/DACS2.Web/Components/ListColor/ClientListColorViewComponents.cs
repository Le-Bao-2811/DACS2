using DACS2.Data.Entities;
using DACS2.Data.Reponsitory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DACS2.Web.Components.ListColor
{
    public class ClientListColorViewComponents:ViewComponent
    {
        readonly BaseReponsitory repository;
        public ClientListColorViewComponents(BaseReponsitory _repository)
        {
            repository = _repository;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var data = await repository.GetAll<Color>().Where(x => x.IdProduct == id).ToListAsync();
            return View(data);
        }
    }
}
