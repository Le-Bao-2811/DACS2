using System.ComponentModel;

namespace DACS2.Web.Areas.Admin.ViewModel.Product
{
    public class UpdateAmount
    {
        public int Id { get; set; }
        [DisplayName("Màu sắc")]
        public string ColorName { get; set; }
        [DisplayName("Số lượng")]
        public int Amount { get; set; }
        public int IdProduct { get; set; }
    }
}
