using Microsoft.AspNetCore.Mvc;
namespace HelloWorldMVC.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Info"]="I am new user for mvc";
            return View();
        }

         public IActionResult AboutMe()
        {
            TempData["Info"]="I am temp data from about me action";
            return View();
        }  
         public string  Hi()
        {         
            return TempData["Info"].ToString();
        }    
    }
}