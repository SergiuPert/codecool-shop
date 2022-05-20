using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Microsoft.AspNetCore.Mvc;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;
using Microsoft.Extensions.Logging;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Codecool.CodecoolShop.Controllers {
    public class CheckoutController : Controller {

        private readonly ILogger<CheckoutController> _logger;
        private OrderService OrderService { get; set; }

        public CheckoutController(ILogger<CheckoutController> logger,OrderService orderService) {
            _logger = logger;
            OrderService = orderService;
        }

        [HttpGet]
        [Route("/Checkout/CheckoutPage")]
        public IActionResult Index() {
            string userId = Encoding.ASCII.GetString(HttpContext.Session.Get("user"));
            return View("CheckoutPage",
                new Checkout() { Order = OrderService.GetOrder(userId)});
        }

        [HttpPost]
        [Route("/Checkout/CheckoutPage")]
        public IActionResult ValidationCheckout(Checkout model) {
            string userId = Encoding.ASCII.GetString(HttpContext.Session.Get("user"));
            return (ModelState.IsValid)?RedirectToAction("Index", "Payment"):View("CheckoutPage",
                new Checkout() { Order = OrderService.GetOrder(userId) });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
            => View(new ErrorViewModel { RequestId = Activity
                .Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
