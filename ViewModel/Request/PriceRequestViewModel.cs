using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElPalacio.Domain.ViewModel.Request
{
    public class PriceRequestViewModel
    {
        public int Id { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductFK { get; set; }
        public bool Active { get; set; }
    }
}
