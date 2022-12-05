namespace DACS2.Web.ViewModels.Client
{
    public class ClientListAllProducts
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string slug { get; set; }
        public string? pathImgP { get; set; }
        public int IdProductCategory { get; set; }

    }
}
