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
    public class PaymentController : Controller {
        private readonly ILogger<PaymentController> _logger;
        private OrderService OrderService { get; set; }

        public PaymentController(ILogger<PaymentController> logger,OrderService orderService) {
            _logger = logger;
            OrderService = orderService;
        }

        [Route("/Payment/PaymentPage")]
        public IActionResult Index() {
            string userId = Encoding.ASCII.GetString(HttpContext.Session.Get("user"));
            return View("PaymentPage",
                new PaymentModel() { Order = OrderService.GetOrder(userId)});
        }

        [HttpPost]
        [Route("/Payment/PaymentComplete")]
        public IActionResult ProcessPayment(PaymentModel paymentModel) {
            return (ModelState.IsValid)?View("PaymentComplete"):View("PaymentPage",paymentModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
            => View(new ErrorViewModel { RequestId = Activity
                .Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
