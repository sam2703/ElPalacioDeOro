using ElPalacio.Domain.Entities;
using ElPalacio.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElPalacio.Data.Repository
{
    public class CheckoutRepository : BaseRepository<Checkout>, ICheckoutRepository
    {
        private readonly ElPalacioContext _context;
        public CheckoutRepository(ElPalacioContext context) : base(context)
        {
            _context = context;
        }
    }
}
