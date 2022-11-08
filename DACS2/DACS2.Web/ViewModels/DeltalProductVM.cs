namespace DACS2.Web.ViewModels
{
    public class DeltalProductVM
    {
        public int Id { get; set; }
        public string ProductName { get; set; } // tên sp
        public string Description { get; set; } // tên sp
        public int Price { get; set; }
        public int Amount { get; set; }
        public int Sold { get; set; } // đã bán
        public string slug { get; set; }
        public string? pathImgP { get; set; }
        public string Suppler { get; set; }
    }
}
