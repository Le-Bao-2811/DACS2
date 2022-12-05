using DACS2.Data.Entities;

namespace DACS2.Web.ViewModels.Cart
{
    public class SelectCartByUserVM
    {
        public int Id { get; set; }

        public string NameCustomer { get; set; }
        public string Address { get; set; }
        public string NumberPhone { get; set; }
        public decimal TotalMoney { get; set; }
        public string Statuscart { get; set; }
        public int? CreateBy { get; set; }
        public ICollection<InvoiceDetails> InvoiceDetails { get; set; }
    }
}
