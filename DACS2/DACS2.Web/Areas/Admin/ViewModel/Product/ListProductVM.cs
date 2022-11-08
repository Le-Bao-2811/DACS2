namespace DACS2.Web.Areas.Admin.ViewModel.Product
{
    public class ListProductVM
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int? ImportPrice { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public string ProductCategory { get; set; }
        public string Suplier { get; set; }
    }
}
