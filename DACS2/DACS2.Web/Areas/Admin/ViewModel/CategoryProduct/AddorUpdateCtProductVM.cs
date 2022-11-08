namespace DACS2.Web.Areas.Admin.ViewModel.CategoryProduct
{
    public class AddorUpdateCtProductVM
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public IFormFile Image { get; set; }
        public int? pathImg { get; set; }
    }
}
