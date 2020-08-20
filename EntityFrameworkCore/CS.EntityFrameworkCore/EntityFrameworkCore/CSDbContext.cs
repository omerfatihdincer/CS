using CS.Core.Order;
using CS.Core.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CS.EntityFrameworkCore.EntityFrameworkCore
{
    public class CSDbContext : DbContext
    {
        public CSDbContext()
        { }
        public CSDbContext(DbContextOptions<CSDbContext> options)
           : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = new CSDbConfigration().GetConnectionString();
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>(b =>
            {
                b.HasKey(c => c.ProductID);
                b.Property(r => r.ProductName).IsRequired();
                b.Property(r => r.QuantityPerUnit).IsRequired();
            });

            modelBuilder.Entity<Order>(b =>
            {
                b.HasKey(c => c.OrderID);
            });

            modelBuilder.Entity<OrderDetail>(b =>
            {
                b.HasKey(c => c.OrderDetailID);
            });
        }


        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}


