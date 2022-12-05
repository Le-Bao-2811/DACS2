using DACS2.Share.Attributes;

namespace DACS2.Web.ViewModels.Cart
{
    public class ShoppingVM
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string NumberPhone { get; set; }
        public string? useVoucher { get; set; }     
        public decimal totalMoney { get; set; }     
    }
}
