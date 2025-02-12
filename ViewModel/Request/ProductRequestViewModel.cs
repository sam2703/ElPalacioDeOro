namespace ElPalacio.Domain.ViewModel.Requests
{
    public class ProductRequestViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Sku { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryFK { get; set; }
        public bool Active { get; set; }
    }
}