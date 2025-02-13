using ElPalacio.Domain.Entities;
using ElPalacio.Domain.IRepository;

namespace ElPalacio.Data.Repository
{
    public class ShopListRepository : BaseRepository<ShopList>, IShopListRepository
    {
        private readonly ElPalacioContext _context;
        public ShopListRepository(ElPalacioContext context) : base(context)
        {
            _context = context;
        }
    }
}