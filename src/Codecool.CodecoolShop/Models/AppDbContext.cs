using Microsoft.EntityFrameworkCore;

namespace Codecool.CodecoolShop.Models {
	public class AppDbContext:DbContext {
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
		public DbSet<Product> Products { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderItem> Items { get; set; }
		public DbSet<Supplier> Suppliers { get; set; }
		public DbSet<ProductCategory> ProductCategories { get; set; }
		//public DbSet<CheckOut> CheckOutDetails { get; set; }
		//protected override void OnModelCreating(ModelBuilder modelBuilder) {
			// move Startup.SetupInMemoryDatabases here
		//}
	}
}

