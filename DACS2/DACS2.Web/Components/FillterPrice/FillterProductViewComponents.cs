using DACS2.Data.Reponsitory;
using Microsoft.AspNetCore.Mvc;

namespace DACS2.Web.Components.FillterPrice
{
    public class FillterProductViewComponents : ViewComponent
    {
        readonly BaseReponsitory repository;
        public FillterProductViewComponents(BaseReponsitory _repository)
        {
            repository = _repository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var filter = new FillterPriceVM();
            filter.Items.AddRange(new FIlterPrice[]
            {
                new FIlterPrice
                {
                    Id = 1,
                    Name = "price",
                    To=0,
                    From=100000
                },
                new FIlterPrice
                {
                    Id = 2,
                    Name = "price",
                    To=100000,
                    From=200000
                },
                 new FIlterPrice
                {
                    Id = 3,
                    Name = "price",
                    To=200000,
                    From=500000
                },
                   new FIlterPrice
                {
                    Id = 4,
                    Name = "price",
                    To=500000,
                    From=1000000
                },
                   new FIlterPrice
                {
                    Id = 5,
                    Name = "price",
                    To=1000000,
                    From=0,
                },
            });
            return View(filter);
        }
    }
}
