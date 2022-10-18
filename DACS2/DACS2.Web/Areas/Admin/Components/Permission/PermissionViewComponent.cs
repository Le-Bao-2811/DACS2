using DACS2.Data.Entities;
using DACS2.Data.Reponsitory;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using X.PagedList;
namespace DACS2.Web.Areas.Admin.Components.Permission
{
    public class PermissionViewComponent:ViewComponent
    {
        readonly BaseReponsitory repository;
        public PermissionViewComponent(BaseReponsitory _repository)
        {
            repository = _repository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await repository
                            .GetAllMst<MstPerMission>()
                            .AsEnumerable()
                            .GroupBy(x => x.GroupName)
                            .ToListAsync();
            return View(data);
        }
    }
}
