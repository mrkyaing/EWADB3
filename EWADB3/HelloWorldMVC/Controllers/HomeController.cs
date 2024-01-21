using Microsoft.AspNetCore.Mvc;

namespace HelloWorldMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public HomeController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            
        }
        //http://localhost:3000/home/index
        public IActionResult Index()
        {
            int hour = DateTime.Now.Hour;
            string message = hour > 12 ? "Good Afternoon,Time is " + DateTime.Now.ToShortTimeString() 
                                                                : "Good Morning,Time is " + DateTime.Now.ToShortTimeString();
            ViewBag.TimeInfo = message;
            return View();
        }
        //http://locahost:3000/home/SayHello
        public string SayHello()
        {
            return "Hi, i am new developer with mvc";
        }
        //http://locahost:3000/home/TellMeTime
        public string TellMeTime()
        {
            return DateTime.Now.ToShortTimeString();
        }

        public ViewResult List()
        {
            ViewBag.Friends = new string[] { "Mg Mg ","Su Su","Aye Aye"};
            return View();
        }
        //http://locahost:3000/home/Add?n1=10&n2=10
        public string Add(int n1,int n2)
        {
            return $"Calculated Result:{(n1 + n2).ToString()}";
        }

        public FileResult Download(){
            string fileName="KAPYINFOS.png";
            string filePath=Path.Combine(_webHostEnvironment.WebRootPath,"DownloadFiles//"+fileName);
            byte[] byteInfFile=System.IO.File.ReadAllBytes(filePath);
            return File(byteInfFile,"text/png",fileName);
        }

        public ViewResult FullName(string firstName,string lastName){
            string FullName="Hello,"+firstName+" " +lastName;
            ViewBag.FullNameInfo=FullName;
            return View();
        }
    }
}
