using ElPalacio.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElPalacio.Domain.ViewModel.Requests
{
    public class ShopListRequestViewModel
    {
        public int Id { get; set; }
        public int CheckoutFK { get; set; }
        public bool FreeDelivery { get; set; }
        public bool? Active { get; set; }
    }
}