namespace DACS2.Web.Components.FillterPrice
{
    public class FillterPriceVM
    {
        public FillterPriceVM() {
            Items = new List<FIlterPrice>();
        }
        public List<FIlterPrice> Items { get; set; }
    }
    public class FIlterPrice
    {
        public int Id { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public string Name { get; set; }
    }
}
