using CloudHRMS.Models.DataModels;
using CloudHRMS.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Entry()
        {
            var departments = _applicationDbContext.Departments.Select(s => new DepartmentViewModel
            {
                Id=s.Id,
                Code=s.Code
            }).OrderBy(o=>o.Code).ToList();
            ViewBag.Departments = departments;
            var positions = _applicationDbContext.Positions.Select(s => new PositionViewModel
            {
                Id = s.Id,
                Code = s.Code
            }).OrderBy(o => o.Code).ToList();
            ViewBag.Positions = positions;
            return View();
        }

        [HttpPost]
        public IActionResult Entry(EmployeeViewModel ui)//e001 
        {
            try
            {
                var IsValidCode = _applicationDbContext.Employees.Where(w => w.Code == ui.Code).Any();
                if (IsValidCode)
                {
                    ViewBag.info = "Code is duplicate in system.";
                    return View();
                }
                var IsValidEmail = _applicationDbContext.Employees.Where(w => w.Email == ui.Email).Any();
                if (IsValidEmail)
                {
                    ViewBag.info = "Email is duplicate in system.";
                    return View();
                }
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
                    DepartmentId=ui.DepartmentId,
                    PositionId=ui.PositionId
                };
                _applicationDbContext.Employees.Add(employee);
                _applicationDbContext.SaveChanges();
                TempData["info"] = "Save process is completed successfully.";
            }
            catch (Exception ex)
            {
                TempData["info"] = "Error occur when save process was done.";
            }
            return RedirectToAction("List");
        }

        public IActionResult List()
        {
            //Data Exchange from Data Model to View Model
            //DTO
            IList<EmployeeViewModel> employees =(from e in _applicationDbContext.Employees
                                                                                         join d in _applicationDbContext.Departments
                                                                                         on e.DepartmentId equals d.Id
                                                                                         join p in _applicationDbContext.Positions
                                                                                         on e.PositionId equals p.Id select new EmployeeViewModel
            //IList<EmployeeViewModel> employees = _applicationDbContext.Employees.Select(s => new EmployeeViewModel
            {
                Id = e.Id,
                Name = e.Name,
                Email = e.Email,
                DOB = e.DOB,
                BasicSalary = e.BasicSalary,
                Address = e.Address,
                Gender = e.Gender,
                Phone = e.Phone,
                Code = e.Code,
                DOE = e.DOE,
                DepartmentInfo=d.Name,//_applicationDbContext.Departments.Where(d=>d.Id==s.DepartmentId).FirstOrDefault().Name,
                PositionInfo=p.Name//_applicationDbContext.Positions.Where(d => d.Id == s.PositionId).FirstOrDefault().Name,
            }).ToList();
            return View(employees);
        }
        public IActionResult Delete(string id)
        {
            try
            {
                var employee = _applicationDbContext.Employees.Find(id);
                if (employee is not null)
                {
                    _applicationDbContext.Remove(employee);
                    _applicationDbContext.SaveChanges();
                }
                TempData["info"] = "Delete process is completed successfully.";
            }
            catch (Exception ex)
            {
                TempData["info"] = "Error occur when delete process was done.";
            }
            return RedirectToAction("List");
        }
       public IActionResult Edit(string id)
        {
            var departments = _applicationDbContext.Departments.Select(s => new DepartmentViewModel
            {
                Id = s.Id,
                Code = s.Code
            }).OrderBy(o => o.Code).ToList();
          
            var positions = _applicationDbContext.Positions.Select(s => new PositionViewModel
            {
                Id = s.Id,
                Code = s.Code
            }).OrderBy(o => o.Code).ToList();        
            EmployeeViewModel employee = _applicationDbContext.Employees.Where(x => x.Id == id).Select(s => new EmployeeViewModel
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email,
                DOB = s.DOB,
                BasicSalary = s.BasicSalary,
                Address = s.Address,
                Gender = s.Gender,
                Phone = s.Phone,
                Code = s.Code,
                DOE = s.DOE,
                DepartmentId=s.DepartmentId,
                PositionId=s.PositionId
            }).SingleOrDefault();
            ViewBag.Departments = departments;
            ViewBag.Positions = positions;
            return View(employee);
        }
        [HttpPost]
        public IActionResult Update(EmployeeViewModel ui)
        {
            try
            {
                //Data exchange from view model to data model
                var employee = new EmployeeEntity()
                {
                    Id = ui.Id,//update the recrod with  the existing id 
                    Code = ui.Code,
                    Name = ui.Name,
                    Email = ui.Email,
                    Phone = ui.Phone,
                    DOB = ui.DOB,
                    DOE = ui.DOE,
                    Address = ui.Address,
                    BasicSalary = ui.BasicSalary,
                    Gender = ui.Gender,
                    ModifiedAt = DateTime.Now,
                    DepartmentId = ui.DepartmentId,
                    PositionId = ui.PositionId
                };
                _applicationDbContext.Employees.Update(employee);
                _applicationDbContext.SaveChanges();
                TempData["info"] = "Update process is completed successfully.";
            }
            catch (Exception ex)
            {
                TempData["info"] = "Error occur when update process was done.";
            }
            return RedirectToAction("List");
        }       
    }
}
