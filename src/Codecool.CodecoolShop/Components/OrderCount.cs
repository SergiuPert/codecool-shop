using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Codecool.CodecoolShop.Components {
	public class OrderCount:ViewComponent {
		private readonly OrderService _orderService;
		public OrderCount(OrderService orderService) {
			_orderService=orderService;
		}
		public IViewComponentResult Invoke() {
			byte[] thing = HttpContext.Session.Get("user");
			if(thing is not null) {
				string userId = Encoding.ASCII.GetString(thing);
				Order order = _orderService.GetOrder(userId);
				ViewBag.ItemCount=order.Count();
			}
			else ViewBag.ItemCount=0;
			return View();
		}
	}
}
