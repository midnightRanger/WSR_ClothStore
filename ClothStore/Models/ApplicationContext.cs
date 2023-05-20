using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ClothStore.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderProduct> OrderProduct { get; set; }
        public DbSet<PickupPoint> PickupPoint { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }


        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }

        public ApplicationContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderProduct>().HasKey(sc => new { sc.OrderID, sc.ProductArticleNumber });

            modelBuilder.Entity<OrderProduct>()
                         .HasOne<Product>(sc => sc.Product)
    .WithMany(s => s.OrderProducts)
    .HasForeignKey(sc => sc.ProductArticleNumber);


            modelBuilder.Entity<OrderProduct>()
                .HasOne<Order>(sc => sc.Order)
                .WithMany(s => s.OrderProducts)
                .HasForeignKey(sc => sc.OrderID);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost; Database=ClothStore; Trusted_Connection=true; Integrated Security=SSPI; TrustServerCertificate=true;");
        }


    }
}
