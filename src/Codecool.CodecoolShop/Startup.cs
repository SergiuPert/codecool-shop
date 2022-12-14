using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Codecool.CodecoolShop {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) {
            services.AddControllersWithViews();
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<AppDbContext>();
            services.AddScoped<IOrderDao,OrderDaoDb>()
                .AddScoped<IProductCategoryDao,ProductCategoryDaoDb>()
                .AddScoped<IProductDao,ProductDaoDb>()
                .AddScoped<ISupplierDao,SupplierDaoDb>()
                .AddScoped<ProductService>()
                .AddScoped<OrderService>()
                .AddHttpContextAccessor()
                .AddSession();
                services.AddControllersWithViews();
                services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            else app.UseExceptionHandler("/Product/Error").UseHsts();
            app.UseHttpsRedirection()
                .UseStaticFiles()
                .UseSession()
                .UseRouting()
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints => {
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Product}/{action=Index}/{id?}");
                    endpoints.MapRazorPages();
            });

           // SetupInMemoryDatabases();
        }

        //private void SetupInMemoryDatabases() {//this needs to move to AppDbContext.OnModelCreating
        //    IProductDao productDataStore = ProductDaoMemory.GetInstance();
        //    IProductCategoryDao productCategoryDataStore = ProductCategoryDaoMemory.GetInstance();
        //    ISupplierDao supplierDataStore = SupplierDaoMemory.GetInstance();
        //    IOrderDao orderDataStore= OrderDaoMemory.GetInstance();

        //    Supplier amazon = new Supplier{Name = "Amazon", Description = "Digital content and services"};
        //    supplierDataStore.Add(amazon);
        //    Supplier lenovo = new Supplier{Name = "Lenovo", Description = "Computers"};
        //    supplierDataStore.Add(lenovo);
        //    Supplier asus = new Supplier { Name = "Asus", Description = "Cellpphone" };
        //    supplierDataStore.Add(asus);
        //    Supplier apple = new Supplier { Name = "Apple", Description = "Digital content and services" };
        //    supplierDataStore.Add(apple);

        //    ProductCategory tablet = new ProductCategory { Name = "Tablet", Department = "Hardware", Description = "A tablet computer, commonly shortened to tablet, is a thin, flat mobile computer with a touchscreen display." };
        //    ProductCategory laptop = new ProductCategory { Name = "Laptop", Department = "Hardware", Description = "A God damn laptop, seriously, you know what a laptop is." };
        //    productCategoryDataStore.Add(tablet);
        //    productCategoryDataStore.Add(laptop);

        //    productDataStore.Add(new Product { Name = "Amazon Fire", DefaultPrice = 49.9m, Currency = "USD", Description = "Fantastic price. Large content ecosystem. Good parental controls. Helpful technical support.", ProductCategory = tablet, Supplier = amazon });
        //    productDataStore.Add(new Product { Name = "Lenovo IdeaPad Miix 700", DefaultPrice = 479.0m, Currency = "USD", Description = "Keyboard cover is included. Fanless Core m5 processor. Full-size USB ports. Adjustable kickstand.", ProductCategory = laptop, Supplier = lenovo });
        //    productDataStore.Add(new Product { Name = "Amazon Fire HD 8", DefaultPrice = 89.0m, Currency = "USD", Description = "Amazon's latest Fire HD 8 tablet is a great value for media consumption.", ProductCategory = tablet, Supplier = amazon });
        //    productDataStore.Add(new Product { Name = "Asus Phone", DefaultPrice = 69.0m, Currency = "USD", Description = "BS", ProductCategory = tablet, Supplier = asus });
        //    productDataStore.Add(new Product { Name = "IPad Pro", DefaultPrice = 49.9m, Currency = "USD", Description = "Fantastic price. Large content ecosystem. Good parental controls. Helpful technical support.", ProductCategory = tablet, Supplier = apple });

        //    Order order = new(1);
        //    orderDataStore.Add(order);
        //}
    }
}
