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

namespace Codecool.CodecoolShop.Controllers
{
    public class PaymentController : Controller
    {
        private readonly ILogger<PaymentController> _logger;
        public OrderService OrderService { get; set; }

        public PaymentController(ILogger<PaymentController> logger)
        {
            _logger = logger;
            OrderService = new OrderService(
                ProductDaoMemory.GetInstance(),
                OrderDaoMemory.GetInstance());
        }


        [Route("/Payment/PaymentPage/{id}")]

        public IActionResult Index(int id = 1)
        {
            var order = OrderService.GetOrder(id);
            return View("PaymentPage", new PaymentModel() { Order = order});
        }
        
        [HttpPost]
        [Route("/Payment/PaymentPage")]
        public IActionResult ProcessPayment(PaymentModel paymentModel)
        {
            string name = paymentModel.FullName;
            return View("PaymentComplete");

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity
                .Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
