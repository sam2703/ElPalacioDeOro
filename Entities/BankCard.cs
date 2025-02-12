using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElPalacio.Domain.Entities
{
    public class BankCard : Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserFK { get; set; }
        public int CardNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int CVV { get; set; }
        public bool Active { get; set; }
        public virtual User User { get; set; }
    }
}