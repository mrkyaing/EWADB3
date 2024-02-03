using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WorkOut.Models;

namespace WorkOut.Controllers
{
    public class EmployeeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(Employee employee)
        {
            ViewBag.Info = $"Hello,{employee.FirstName} {employee.LastName},Nice to see you";
            return View();
        }
        public IActionResult SendInList() => View();
        [HttpPost]
        public IActionResult SendInList(IList<string> Id, IList<string> FirstName, IList<string> LastName)
        {
                ViewBag.Count=Id.Count;
                return View();
        }
        public IActionResult SendEmployees() => View();
        [HttpPost]
        public IActionResult SendEmployees(IList<Employee> employees)
        {
            ViewBag.Count = employees.Count;
            return View();
        }
    }
}