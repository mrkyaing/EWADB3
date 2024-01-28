using AJAXWithJQuery.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
namespace AJAXWithJQuery.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public string  TellMeNow()
        {
            return DateTime.Now.ToLongTimeString();
        }

        public JsonResult Count()
        {
            int count=0;
            count++;
            return Json(count);
        }
        public IActionResult MakeOrder() => View();
        [HttpPost]
        public JsonResult MakeOrder(OrderViewModel order)
        {
            decimal total = order.UnitPrice * order.Quantity;
            return Json(total);
        }
    }
}
