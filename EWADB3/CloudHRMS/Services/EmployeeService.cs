using CloudHRMS.Models.DataModels;
using CloudHRMS.Models.ViewModels;
using CloudHRMS.ReportHelper;
using CloudHRMS.Repostories;
using Microsoft.AspNetCore.Identity;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;

namespace CloudHRMS.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPositionRepository _positionRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly UserManager<IdentityUser> _userManager;
        public EmployeeService(UserManager<IdentityUser> userManager, IEmployeeRepository employeeRepository,IPositionRepository positionRepository,IDepartmentRepository departmentRepository)
        {
            _userManager = userManager;
            this._employeeRepository = employeeRepository;
            this._positionRepository = positionRepository;
            this._departmentRepository = departmentRepository;
        }
        public async Task Create(EmployeeViewModel ui)
        {
            try
            {
                var IsPositionCodeAlreadyExists = _employeeRepository.GetAll().Where(w => w.Code == ui.Code).Any();
                if(IsPositionCodeAlreadyExists)
                {
                    throw new Exception("Code already exists in the system.");
                }
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
                }; try
                {
                    _employeeRepository.Create(employee);
                    var user = new IdentityUser { UserName = ui.Email, Email = ui.Email };
                    var result = await _userManager.CreateAsync(user, "CloudHRMS@prodev@123");
                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, "EMPLOYEE");
                    }
                }catch (Exception ex)
                {
                    throw;
                }
                }       
            catch (Exception)
            {
                throw;
            }
        }
        public void Delete(string id)
        {
            _employeeRepository.Delete(id);
        }

        public IList<EmployeeViewModel> GetAll()
        {
           return (from e in _employeeRepository.GetAll()
                                                  join d in _departmentRepository.GetAll()
                                                  on e.DepartmentId equals d.Id
                                                  join p in _positionRepository.GetAll()
                                                  on e.PositionId equals p.Id
                                                  select new EmployeeViewModel
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
                                                      DepartmentInfo = d.Name,
                                                      PositionInfo = p.Name,
                                                      ProfilePicture = e.ProfilePicture ?? ""
                                                  }).ToList();
        }
        public IList<EmployeeDetail> GetByFromCodeToCodeDepartentId(string fromCode, string toCode, string DeprtmentId)
        {
            return (from e in _employeeRepository.GetAll()
                    join d in _departmentRepository.GetAll()
                    on e.DepartmentId equals d.Id
                    join p in _positionRepository.GetAll()
                    on e.PositionId equals p.Id
                    where (e.Code.CompareTo(fromCode)>=0&&e.Code.CompareTo(toCode)<=0) || e.DepartmentId==DeprtmentId
                    select new EmployeeDetail
                    {
                        Name = e.Name,
                        Email = e.Email,
                        DOB = e.DOB,
                        BasicSalary = e.BasicSalary,
                        Address = e.Address,
                        Gender = e.Gender,
                        Phone = e.Phone,
                        Code = e.Code,
                        DOE = e.DOE,
                        DepartmentInfo = d.Name,
                        PositionInfo = p.Name,
                        ProfilePicture = e.ProfilePicture ?? ""
                    }).ToList();
        }
        public EmployeeViewModel GetById(string id)
        {
            var e = _employeeRepository.GetById(id);
            var d = _departmentRepository.GetById(e.DepartmentId);
            var p = _positionRepository.GetById(e.PositionId);
           return new EmployeeViewModel()
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
               DepartmentInfo = d.Name,
               PositionInfo = p.Name,
               ProfilePicture = e.ProfilePicture ?? ""
           };
        }
        public void Update(EmployeeViewModel ui)
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
            _employeeRepository.Update(employee);
        }
    }
}
