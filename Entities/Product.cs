using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElPalacio.Domain.Entities
{
    public class Product : Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(150)]
        public string Name { get; set; }
        [MaxLength(300)]
        public string Description { get; set; }
        public int Sku { get; set; }
        public int StockQuantity { get; set; }
        [ForeignKey("Category")]
        public int CategoryFK { get; set; }
        public bool Active { get; set; }
        public virtual Category Category { get; set; }
    }
}