using GroceryHX.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GroceryHX.Data
{
    public class AppDbContext:IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country_Product>().HasKey(am => new
            {
                am.CountryId,
                am.ProductId
            });

            modelBuilder.Entity<Country_Product>().HasOne(m => m.Product).WithMany(am => am.Country_Products).HasForeignKey(m => m.ProductId);
            modelBuilder.Entity<Country_Product>().HasOne(m => m.Country).WithMany(am => am.Country_Products).HasForeignKey(m => m.CountryId);


            base.OnModelCreating(modelBuilder);
        }

		public DbSet<Country> Countries { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Country_Product> Country_Product { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Producer> Producers { get; set; }

        //Orders related tables
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set;}
    }
}
