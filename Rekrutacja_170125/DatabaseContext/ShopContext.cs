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
        public DbSet<OrderProductEntity> OrderProducts { get; set; }

        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrderProductEntity>()
                .HasKey(op => new { op.OrderId, op.ProductId });

            modelBuilder.Entity<OrderProductEntity>()
                .HasOne(op => op.Order)
                .WithMany(o => o.OrderProducts)
                .HasForeignKey(op => op.OrderId);

            modelBuilder.Entity<OrderProductEntity>()
                .HasOne(op => op.Product)
                .WithMany(p => p.OrderProducts)
                .HasForeignKey(op => op.ProductId);

            modelBuilder.Entity<ShopEntity>().HasData(
                new ShopEntity { Id = 1, Name = "Sklep 1" },
                new ShopEntity { Id = 2, Name = "Sklep 2" },
                new ShopEntity { Id = 3, Name = "Sklep 3" },
                new ShopEntity { Id = 4, Name = "Sklep 4" },
                new ShopEntity { Id = 5, Name = "Sklep 5" },
                new ShopEntity { Id = 6, Name = "Sklep 6" },
                new ShopEntity { Id = 7, Name = "Sklep 7" },
                new ShopEntity { Id = 8, Name = "Sklep 8" },
                new ShopEntity { Id = 9, Name = "Sklep 9" },
                new ShopEntity { Id = 10, Name = "Sklep 10" }
            );

            modelBuilder.Entity<ProductEntity>().HasData(
                new ProductEntity { Id = 1, Name = "P001", NetPrice = 100.0m, GrossPrice = 123.0m },
                new ProductEntity { Id = 2, Name = "P002", NetPrice = 200.0m, GrossPrice = 246.0m },
                new ProductEntity { Id = 3, Name = "P003", NetPrice = 150.0m, GrossPrice = 184.5m },
                new ProductEntity { Id = 4, Name = "P004", NetPrice = 180.0m, GrossPrice = 221.4m },
                new ProductEntity { Id = 5, Name = "P005", NetPrice = 250.0m, GrossPrice = 307.5m },
                new ProductEntity { Id = 6, Name = "P006", NetPrice = 120.0m, GrossPrice = 147.6m },
                new ProductEntity { Id = 7, Name = "P007", NetPrice = 80.0m, GrossPrice = 98.4m },
                new ProductEntity { Id = 8, Name = "P008", NetPrice = 190.0m, GrossPrice = 233.7m },
                new ProductEntity { Id = 9, Name  = "P009", NetPrice = 220.0m, GrossPrice = 270.6m },
                new ProductEntity { Id = 10, Name = "P010", NetPrice = 130.0m, GrossPrice = 159.9m }
            );

            modelBuilder.Entity<ClientEntity>().HasData(
                new ClientEntity { Id = 1, Street = "Street 1", City = "Cityw 1", PostalCode = "11111" },
                new ClientEntity { Id = 2, Street = "Street 2", City = "City 2", PostalCode = "22222" },
                new ClientEntity { Id = 3, Street = "Street 3", City = "City 3", PostalCode = "33333" },
                new ClientEntity { Id = 4, Street = "Street 4", City = "Cityw 4", PostalCode = "44444" },
                new ClientEntity { Id = 5, Street = "Street 5", City = "City 5", PostalCode = "55555" },
                new ClientEntity { Id = 6, Street = "Street 6", City = "City 6", PostalCode = "66666" },
                new ClientEntity { Id = 7, Street = "Street 7", City = "Cityw 7", PostalCode = "77777" },
                new ClientEntity { Id = 8, Street = "Street 8", City = "City 8", PostalCode = "88888" },
                new ClientEntity { Id = 9, Street = "Street 9", City = "City 9", PostalCode = "99999" },
                new ClientEntity { Id = 10, Street = "Street 10", City = "City 10", PostalCode = "10101" }
            );

            modelBuilder.Entity<OrderEntity>().HasData(
                new OrderEntity { Id = 1, ShopId = 1, ClientId = 1, PaymentMethod = PaymentMethod.Cash },
                new OrderEntity { Id = 2, ShopId = 2, ClientId = 2, PaymentMethod = PaymentMethod.Card },
                new OrderEntity { Id = 3, ShopId = 3, ClientId = 3, PaymentMethod = PaymentMethod.Transfer },
                new OrderEntity { Id = 4, ShopId = 4, ClientId = 4, PaymentMethod = PaymentMethod.Cash },
                new OrderEntity { Id = 5, ShopId = 5, ClientId = 5, PaymentMethod = PaymentMethod.Card },
                new OrderEntity { Id = 6, ShopId = 6, ClientId = 6, PaymentMethod = PaymentMethod.Transfer },
                new OrderEntity { Id = 7, ShopId = 7, ClientId = 7, PaymentMethod = PaymentMethod.Cash },
                new OrderEntity { Id = 8, ShopId = 8, ClientId = 8, PaymentMethod = PaymentMethod.Card },
                new OrderEntity { Id = 9, ShopId = 9, ClientId = 9, PaymentMethod = PaymentMethod.Transfer },
                new OrderEntity { Id = 10, ShopId = 10, ClientId = 10, PaymentMethod = PaymentMethod.Cash }
            );

            modelBuilder.Entity<OrderProductEntity>().HasData(
                new OrderProductEntity { OrderId = 1, ProductId = 1, Quantity = 2 },
                new OrderProductEntity { OrderId = 2, ProductId = 2, Quantity = 1 },
                new OrderProductEntity { OrderId = 3, ProductId = 10, Quantity = 5 },
                new OrderProductEntity { OrderId = 4, ProductId = 5, Quantity = 1 },
                new OrderProductEntity { OrderId = 5, ProductId = 3, Quantity = 2 },
                new OrderProductEntity { OrderId = 6, ProductId = 4, Quantity = 5 },
                new OrderProductEntity { OrderId = 7, ProductId = 3, Quantity = 3 },
                new OrderProductEntity { OrderId = 8, ProductId = 2, Quantity = 5 },
                new OrderProductEntity { OrderId = 9, ProductId = 3, Quantity = 4 },
                new OrderProductEntity { OrderId = 10, ProductId = 1, Quantity = 5 }

            );
        }

    }
}
