namespace ElPalacio.Domain.ViewModel
{
    public class UserViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool Active { get; set; }
        public string Password { get; set; }

    }
}