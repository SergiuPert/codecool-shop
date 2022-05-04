using Microsoft.AspNetCore.Mvc;

namespace Codecool.CodecoolShop.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Cart()
        {

            return View();
        }
    }
}
