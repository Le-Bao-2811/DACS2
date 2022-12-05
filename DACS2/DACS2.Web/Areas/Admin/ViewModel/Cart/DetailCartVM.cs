using DACS2.Data.Entities;

namespace DACS2.Web.Areas.Admin.ViewModel.Cart
{
    public class DetailCartVM
    {
        public int Id { get; set; }

        public string NameCustomer { get; set; }
        public string Address { get; set; }
        public string NumberPhone { get; set; }
        public decimal TotalMoney { get; set; }
        public int StatusId { get; set; }
        public ICollection<InvoiceDetails> InvoiceDetails { get; set; }
    }
}
