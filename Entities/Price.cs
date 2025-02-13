using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElPalacio.Domain.Entities
{
    public class Price : Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal ProductPrice { get; set; }
        [ForeignKey("Product")]
        public int ProductFK { get; set; }
        public bool Active { get; set; }
        public virtual Product Product { get; set; }
    }
}