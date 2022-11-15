using System.ComponentModel;

namespace DACS2.Web.Areas.Admin.ViewModel.Product
{
    public class AddProductVM
    {
        public int Id { get; set; }
        [DisplayName("Tên sản phẩm")]
        public string ProductName { get; set; } // tên sp
        [DisplayName("Giá nhập")]
        public int? ImportPrice { get; set; } // giá nhập
        public string? pathImgP { get; set; }
        public IFormFile ImageP { get; set; }
        public string Description { get; set; } // tên sp
        [DisplayName("Giá bán")]
        public int Price { get; set; }
        [DisplayName("Số lượng")]
        public List<int> Amountdesign { get; set; }
        [DisplayName("Đơn vị tính")]
        public string Unit { get; set; } //đơn vị tính
        public string slug { get; set; }
        [DisplayName("Danh mục")]
        public int IdProductCategory { get; set; }
        [DisplayName("Nhà cung cấp")]
        public int IdSuplier { get; set; }
        [DisplayName("Size")]
        public List<string> Size { get; set; }
        [DisplayName("Màu sắc")]
        public List<string> Color { get; set; }
        
        [DisplayName("Hình ảnh")]
        public List<IFormFile> Image { get; set; }
        public List<string> PathImage { get; set; }

    }
}
