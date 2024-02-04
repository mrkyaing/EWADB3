using CloudHRMS.Models.DataModels;
using CloudHRMS.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net.Sockets;
using System.Net;
using CloudHRMS.DAO;

namespace CloudHRMS.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public EmployeeController(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Entry() => View();

        [HttpPost]
        public IActionResult Entry(EmployeeViewModel ui)
        {
            try
            {
                //Data exchange from view model to data model
                var employee = new EmployeeEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    Code = ui.Code,
                    Name = ui.Name,
                    Email = ui.Email,
                    Phone = ui.Phone,
                    DOB = ui.DOB,
                    DOE = ui.DOE,
                    Address = ui.Address,
                    BasicSalary = ui.BasicSalary,
                    Gender = ui.Gender,
                    IpAddress = this.GetLocalIPAddress()
                };
                _applicationDbContext.Employees.Add(employee);
                _applicationDbContext.SaveChanges();
                ViewBag.Info = "successfully save a record to the system";
            }
            catch (Exception e) 
            {
                ViewBag.Info = "Error occur when  saving a record  to the system";
            }
            return View();
        }
        private  string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}
