using ElPalacio.Domain.Entities;
using ElPalacio.Domain.IRepository;

namespace ElPalacio.Data.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly ElPalacioContext _context;
        public CategoryRepository(ElPalacioContext context) : base(context)
        {
            _context = context;
        }
    }
}