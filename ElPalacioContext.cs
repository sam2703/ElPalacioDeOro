using ElPalacio.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ElPalacio.Data
{
    public class ElPalacioContext : DbContext
    {
        public ElPalacioContext(DbContextOptions<ElPalacioContext> options) : base(options)
        {
        }

        #region == [Entities] ==
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Checkout> Checkout { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ShopList> ShopList { get; set; }
        public virtual DbSet<User> User { get; set; }

        #endregion

    }
}
