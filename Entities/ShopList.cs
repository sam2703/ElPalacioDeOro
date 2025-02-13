using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElPalacio.Domain.Entities
{
    public class ShopList : Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Checkout")]
        public int CheckoutFK { get; set; }
        public bool FreeDelivery { get; set; }
        public bool? Active { get; set; }
        public virtual Checkout Checkout { get; set; }
    }
}