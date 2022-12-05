using Microsoft.AspNetCore.Http;
using System.ComponentModel;

namespace DACS2.Web.Areas.Admin.ViewModel.Product
{
    public class DetailsProductVM
    {
        public int Id { get; set; }
        [DisplayName("Tên sản phẩm")]
        public string ProductName { get; set; } // tên sp
        [DisplayName("Giá nhập")]
        public int? ImportPrice { get; set; } // giá nhập
        public string? pathImgP { get; set; }
        public string Description { get; set; } // tên sp
        [DisplayName("Giá bán")]
        public int Price { get; set; }
        [DisplayName("Đơn vị tính")]
        public string Unit { get; set; } //đơn vị tính
        [DisplayName("Danh mục")]
        public string ProductCategory { get; set; }
        [DisplayName("Nhà cung cấp")]
        public string Suplier { get; set; }
        public int IdProductCategory { get; set; }
        public IFormFile? Image { get; set; }
        public int IdSuplier { get; set; }





    }
}
