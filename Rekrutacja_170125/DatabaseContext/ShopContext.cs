using Microsoft.EntityFrameworkCore;
using Rekrutacja_170125.Entities;

namespace Rekrutacja_170125.DatabaseContext
{
    public class ShopContext : DbContext
    {
        public DbSet<ShopEntity> Shops { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<ClientEntity> Clients { get; set; }


        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {
            
        }
    }
}
