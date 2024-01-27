using Microsoft.AspNetCore.Mvc;
namespace WorkOut.Controllers
{
    public class ConvertorController : Controller
    {
        public IActionResult CurrencyConvertorV1()
        {
            return View();
        }
        //localhost:3000/Convertor/CurrencyConvertorV1
        [HttpPost]
        public IActionResult CurrencyConvertorV1(string selectedCurrency,decimal amout)
        {
            decimal convertedAmount = 0;
            switch (selectedCurrency)
            {
                case "USD":convertedAmount = amout * 3000;break;
                case "SDG":convertedAmount = amout * 1200;break;
                case "TBH":convertedAmount = amout * 100;break;
            }
            ViewBag.Amount = convertedAmount;
            return View();
        }


        public IActionResult CurrencyConvertorV2()
        {
            return View();
        }
        //localhost:3000/Convertor/CurrencyConvertorV1
        [HttpPost]
        public IActionResult CurrencyConvertorV2(string selectedCurrency, decimal amout)
        {
            List<string> errors = new();
            if (string.IsNullOrEmpty(selectedCurrency))
            {
                errors.Add("please select a currency");
            }
            if (amout <=0)
            {
                errors.Add("invalid amount");
            }
            if (errors.Count > 0)
            {
                ViewBag.Errors = errors;
                return View();
            }
            decimal convertedAmount = 0;
            switch (selectedCurrency)
            {
                case "USD": convertedAmount = amout * 3000; break;
                case "SDG": convertedAmount = amout * 1200; break;
                case "TBH": convertedAmount = amout * 100; break;
            }
            ViewBag.selectedCurrency = selectedCurrency;
            ViewBag.inputAmount = amout;
            ViewBag.Amount = convertedAmount;
            return View();
        }
    }
}
