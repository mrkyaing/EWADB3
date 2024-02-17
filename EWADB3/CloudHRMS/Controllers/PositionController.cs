using CloudHRMS.DAO;
using CloudHRMS.Models.DataModels;
using CloudHRMS.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;
using System.Net;
namespace CloudHRMS.Controllers
{
    public class PositionController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public PositionController(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }
        public IActionResult List() //Show
        {
            IList<PositionViewModel> positions = _applicationDbContext.Positions.Select(
                 s => new PositionViewModel
                 {
                     Id = s.Id,
                     Code = s.Code,
                     Name = s.Name,
                     Level = s.Level,
                 }).ToList();
            return View(positions);
        }

        public IActionResult Edit(string id)
        {
            if (id != null)
            {
                PositionViewModel position = _applicationDbContext.Positions.Where(x => x.Id == id).Select(s => new PositionViewModel
                {
                    Id = s.Id,
                    Code = s.Code,
                    Name = s.Name,
                    Level = s.Level,
                }).SingleOrDefault();
                return View(position);
            }
            else
            {
                return RedirectToAction("List");
            }
        }
        public IActionResult Delete(string id)
        {
            try
            {
                var position = _applicationDbContext.Positions.Find(id);
                if (position is not null)
                {
                    _applicationDbContext.Remove(position);
                    _applicationDbContext.SaveChanges();
                }
                TempData["Info"] = "Save Successfully";
            }
            catch (Exception ex)
            {
                TempData["Info"] = "Error Occur When Deleting";
            }
            return RedirectToAction("List");
        }
        public IActionResult Entry() => View();

        [HttpPost]
        public IActionResult Entry(PositionViewModel ui)
        {
            try
            {
                //Data exchange from view model to data model
                var position = new PositionEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    Code = ui.Code,
                    Name = ui.Name,
                    Level = ui.Level
                };
                _applicationDbContext.Positions.Add(position);
                _applicationDbContext.SaveChanges();
                ViewBag.Info = "successfully save a record to the system";
            }
            catch (Exception ex)
            {
                ViewBag.Info = "Error occur when  saving a record  to the system";
            }
            return View();
        }
    }
}
