using CloudHRMS.Models.ViewModels;
using CloudHRMS.ReportHelper;

namespace CloudHRMS.Services
{
    public interface IEmployeeService
    {
        Task Create(EmployeeViewModel viewModel);
        IList<EmployeeViewModel> GetAll();
        EmployeeViewModel GetById(string id);
        void Update(EmployeeViewModel viewModel);
        void Delete(string id);
        IList<EmployeeDetail> GetByFromCodeToCodeDepartentId(string fromCode, string toCode, string DeprtmentId);
    }
}
