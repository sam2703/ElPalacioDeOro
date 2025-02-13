using ElPalacio.Domain.Entities;
using ElPalacio.Domain.IRepository;

namespace ElPalacio.Data.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ElPalacioContext _context;
        public UserRepository(ElPalacioContext context) : base(context)
        {
            _context = context;
        }
    }
}