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
    public class OrderController:Controller {
        private readonly ILogger<OrderController> _logger;
        private OrderService OrderService { get; set; }

        public OrderController(ILogger<OrderController> logger,OrderService orderService) {
            _logger=logger;
            OrderService=orderService;
        }

        [Route("/Order/OrderDetails/{id}")]
        public IActionResult OrderDetails(int id = 1) {
            OrderVM orderDetails = new() {
                order=OrderService.GetOrder(id),
                products=OrderService.GetProducts(id)
            };
            return View(orderDetails);
        }

        [Route("/Order/AddToCart/{id}")]
        public void AddToCart(int id) {
            OrderService.AddToOrder(1,id);
            Response.Redirect("/Product/Index");
        }
        
        [Route("/Order/AddQuantity/{id}")]
        public void AddQuantity(int id) {
            OrderService.AddToOrder(1, id);
            Response.Redirect("/Order/OrderDetails/1");
        }
        [Route("/Order/RemoveFromCart/{id}")]
        public void RemoveFromCart(int id) {
            OrderService.RemoveFromOrder(1,id);
            Response.Redirect($"/Order/OrderDetails/1");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
            => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
