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

namespace Codecool.CodecoolShop.Controllers {
    public class ProductController : Controller {
        private readonly ILogger<ProductController> _logger;
        private ProductService ProductService { get; set; }

        public ProductController(ILogger<ProductController> logger,ProductService productService) {
            _logger = logger;
            ProductService = productService;
        }

        [Route("/")]
        [Route("/Product")]
        [Route("/Product/Index")]
        [Route("/Product/Index/{id}")]
        public IActionResult Index(int id=1)
            => View(ProductService.GetProductsForCategory(id).ToList());

        public IActionResult SupplierSort(int id = 1)
            => View(ProductService.GetProductsForSupplier(id).ToList());

        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
            => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
