namespace ElPalacio.Domain.ViewModel
{
    public class PriceViewModel
    {
        public int Id { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductFK { get; set; }
        public bool Active { get; set; }
    }
}