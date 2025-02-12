using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElPalacio.Domain.Entities
{
    public class Checkout : Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("BankCard")]
        public int BankCardFK { get; set; }
        [ForeignKey("Price")]
        public int PriceFK { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal SubTotal { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal DeliveryFee { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Total { get; set; }
        public bool Active { get; set; }
        public virtual BankCard BankCard { get; set; }
        public virtual Price Price { get; set; }
    }
}