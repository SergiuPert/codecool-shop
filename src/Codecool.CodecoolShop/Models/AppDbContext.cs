using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Codecool.CodecoolShop.Models {
	public class AppDbContext:IdentityDbContext<IdentityUser> {
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
		public DbSet<Product> Products { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderItem> Items { get; set; }
		public DbSet<Supplier> Suppliers { get; set; }
		public DbSet<ProductCategory> ProductCategories { get; set; }
        //public DbSet<CheckOut> CheckOutDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            Supplier amazon = new Supplier { Id=1, Name = "Amazon", Description = "Digital content and services" };
            modelBuilder.Entity<Supplier>().HasData(amazon);
            Supplier lenovo = new Supplier { Id = 2, Name = "Lenovo", Description = "Computers" };
            modelBuilder.Entity<Supplier>().HasData(lenovo);
            Supplier asus = new Supplier { Id = 3, Name = "Asus", Description = "Cellpphone" };
            modelBuilder.Entity<Supplier>().HasData(asus);
            Supplier apple = new Supplier { Id = 4, Name = "Apple", Description = "Digital content and services" };
            modelBuilder.Entity<Supplier>().HasData(apple);

            ProductCategory tablet = new ProductCategory { Id = 1, Name = "Tablet", Department = "Hardware", Description = "A tablet computer, commonly shortened to tablet, is a thin, flat mobile computer with a touchscreen display." };
            ProductCategory laptop = new ProductCategory { Id = 2, Name = "Laptop", Department = "Hardware", Description = "A God damn laptop, seriously, you know what a laptop is." };
            modelBuilder.Entity<ProductCategory>().HasData(tablet);
            modelBuilder.Entity<ProductCategory>().HasData(laptop);

            modelBuilder.Entity<Product>().HasData(new Product { Id = 1, Name = "Amazon Fire", DefaultPrice = 49, Currency = "USD", Description = "Fantastic price. Large content ecosystem. Good parental controls. Helpful technical support.", ProductCategoryId = 1, SupplierId = 1 });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 2, Name = "Lenovo IdeaPad Miix 700", DefaultPrice = 479, Currency = "USD", Description = "Keyboard cover is included. Fanless Core m5 processor. Full-size USB ports. Adjustable kickstand.", ProductCategoryId = 2, SupplierId = 2 });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 3, Name = "Amazon Fire HD 8", DefaultPrice = 89, Currency = "USD", Description = "Amazon's latest Fire HD 8 tablet is a great value for media consumption.", ProductCategoryId = 1, SupplierId = 1 });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 4, Name = "Asus Phone", DefaultPrice = 69, Currency = "USD", Description = "BS", ProductCategoryId = 1, SupplierId = 3 });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 5, Name = "IPad Pro", DefaultPrice = 49, Currency = "USD", Description = "Fantastic price. Large content ecosystem. Good parental controls. Helpful technical support.", ProductCategoryId = 1, SupplierId = 4 });

            modelBuilder.Entity<Order>().HasData(new Order { Id = 1, Name = "Cart", Description = "Cart", total = 0, userId = "" });
        }

    }
}

