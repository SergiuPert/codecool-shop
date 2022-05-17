using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;
using Codecool.CodecoolShop.ViewModels;

namespace Codecool.CodecoolShop.Controllers {
    public class ProductController : Controller {
        private readonly ILogger<ProductController> _logger;
        private ProductService ProductService { get; set; }
        private ISupplierDao Supplier { get; set; }
        private IProductCategoryDao ProductCategory { get; set; }

        public ProductController(ILogger<ProductController> logger,ProductService productService, ISupplierDao supplier, IProductCategoryDao productCategory) {
            _logger = logger;
            ProductService = productService;
            Supplier = supplier;
            ProductCategory = productCategory;
        }

        [Route("/")]
        [Route("/Product")]
        [Route("/Product/Index")]
        [Route("/Product/Index/{id}")]
        public IActionResult Index(int id=1)
        {
            var products = ProductService.GetProductsForCategory(id).ToList();
            List<ProductVM> productStuff = new List<ProductVM>();
            foreach (Product p in products)
            {
                ProductVM item = new ProductVM();
                item.product = p;
                item.supplier = Supplier.Get(p.SupplierId);
                item.category = ProductCategory.Get(p.ProductCategoryId);
                productStuff.Add(item);

            }
            return View(productStuff);
        }

        public IActionResult SupplierSort(int id = 1)
        {
            {
                var products = ProductService.GetProductsForSupplier(id).ToList();
                List<ProductVM> productStuff = new List<ProductVM>();
                foreach (Product p in products)
                {
                    ProductVM item = new ProductVM();
                    item.product = p;
                    item.supplier = Supplier.Get(p.SupplierId);
                    item.category = ProductCategory.Get(p.ProductCategoryId);
                    productStuff.Add(item);

                }
                return View(productStuff);
            }
        }

        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
            => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
