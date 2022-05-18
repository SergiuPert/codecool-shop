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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace Codecool.CodecoolShop.Controllers {
    [Authorize]
    public class OrderController:Controller {
        private readonly ILogger<OrderController> _logger;
        private OrderService OrderService { get; set; }
        private ProductService ProductService { get; set; }

        public OrderController(ILogger<OrderController> logger,OrderService orderService,ProductService productService) {
            _logger=logger;
            OrderService=orderService;
            ProductService=productService;
        }

        [Route("/Order/OrderDetails/{id}")]
        public IActionResult OrderDetails(string id) {
            Order order = OrderService.GetOrder(id);
            List<OrderedProduct> itemsVM = new();
            foreach(OrderItem item in order.products) {
                Product p = ProductService.Get(item.ProductId);
                OrderedProduct itemVM = new OrderedProduct() {
                    product=p,
                    category=ProductService.GetProductCategory(p.ProductCategoryId).Department,
                    supplier=ProductService.GetProductSupplier(p.SupplierId).Name,
                    amount=item.amount
                };
                itemsVM.Add(itemVM);
            }
            OrderVM orderDetails = new() {
                order=OrderService.GetOrder(id),
                products=itemsVM
            };
            return View(orderDetails);
        }

        [Route("/Order/AddToCart/{id}")]
        public void AddToCart(int id) {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
    .HttpContext.Session;

            OrderService.AddToOrder(userId,id);
            Response.Redirect("/Product/Index");
        }
        
        [Route("/Order/AddQuantity/{id}")]
        public void AddQuantity(int id) {
            OrderService.AddToOrder(userId, id);
            Response.Redirect($"/Order/OrderDetails/{userId}");
        }
        [Route("/Order/RemoveFromCart/{id}")]
        public void RemoveFromCart(int id) {
            OrderService.RemoveFromOrder(userId,id);
            Response.Redirect($"/Order/OrderDetails/{userId}");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
            => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
