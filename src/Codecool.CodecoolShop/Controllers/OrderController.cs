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
    public class OrderController : Controller {
        private readonly ILogger<OrderController> _logger;
        public OrderService OrderService { get; set; }

        public OrderController(ILogger<OrderController> logger) {
            _logger = logger;
            OrderService= new OrderService(ProductDaoMemory.GetInstance(),OrderDaoMemory.GetInstance());
        }
        public IActionResult OrderDetails(int id=1) {
            Order order = OrderService.GetOrder(id);
            return View(order);
        }
        public IActionResult AddToCart(int id) {
            OrderService.AddToOrder(1,id);
            return RedirectToRoute("/Product/Index");
        }
        public IActionResult RemoveFromCart(int id) {
            OrderService.RemoveFromOrder(1,id);
            return RedirectToRoute($"/Order/EditCart/{id}");
        }
        public IActionResult EditCart(int id) {
            Order order=OrderService.GetOrder(id);
            return View(order);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
