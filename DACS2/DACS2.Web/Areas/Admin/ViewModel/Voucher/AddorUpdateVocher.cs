using System.ComponentModel;

namespace DACS2.Web.Areas.Admin.ViewModel.Voucher
{
    public class AddorUpdateVocher
    {
        public int Id { get; set; }
        [DisplayName("Mã giảm giá")]
        public string VoucherName { get; set; }
        [DisplayName("Số lượng")]
        public int amount { get; set; }
        [DisplayName("Giá giảm")]
        public int? price { get; set; }
        [DisplayName("Giảm theo phần trăm")]
        public int? percent { get; set; }
        [DisplayName("Ngày bắt đầu")]
        public DateTime StartDate { get; set; }
        [DisplayName("Ngày kết thúc")]
        public DateTime EndDate { get; set; }
    }
}
