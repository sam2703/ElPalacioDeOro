namespace ElPalacio.Domain.ViewModel
{
    public class CheckoutViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public int BankCardFK { get; set; }
        public int PriceFK { get; set; }
        public decimal SubTotal { get; set; }
        public decimal DeliveryFee { get; set; }
        public decimal Total { get; set; }
        public bool Active { get; set; }
    }
}