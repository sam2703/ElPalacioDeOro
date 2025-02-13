namespace ElPalacio.Domain.ViewModel
{
    public class BankCarViewModel
    {
        public int Id { get; set; }
        public int UserFK { get; set; }
        public int CardNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int CVV { get; set; }
        public bool Active { get; set; }
    }
}