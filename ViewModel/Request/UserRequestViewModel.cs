namespace ElPalacio.Domain.ViewModel.Requests
{
    public class UserRequestViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool Active { get; set; }
        public string Password { get; set; }
    }
}
