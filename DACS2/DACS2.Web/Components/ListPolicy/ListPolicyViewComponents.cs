using DACS2.Data.Entities;
using DACS2.Data.Reponsitory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DACS2.Web.Components.ListPolicy
{
    public class ListPolicyViewComponents : ViewComponent
    {
        readonly BaseReponsitory repository;
        public ListPolicyViewComponents(BaseReponsitory _repository)
        {
            repository = _repository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await repository.GetAll<Policy>().ToListAsync();
            return View(data);
        }
    }
}
