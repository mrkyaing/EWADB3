using CloudHRMS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Reporting.NETCore;
using System.Text;

namespace CloudHRMS.Controllers
{
    public class EmployeeReportController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;

        public EmployeeReportController(IWebHostEnvironment webHostEnvironment,IEmployeeService employeeService,IDepartmentService departmentService)
        {
            this._webHostEnvironment = webHostEnvironment;
            this._employeeService = employeeService;
            this._departmentService = departmentService;
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }
        public IActionResult ReportByEmployeeFromCode()
        {
            ViewBag.Departments = _departmentService.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult ReportByEmployeeFromCode(string fromCode,string toCode,string departmentId)
        {
            var employeeDetail = _employeeService.GetByFromCodeToCodeDepartentId(fromCode, toCode, departmentId);
            var rdlcPath = $"{_webHostEnvironment.WebRootPath}\\RdlcReportFiles\\EmployeeDetailReport.rdlc";
            if (employeeDetail != null)
            {
                Stream reportDefinition=new FileStream(rdlcPath,FileMode.Open);
                 IList<ReportParameter> paremeters =new List< ReportParameter>();
                paremeters.Add(new ReportParameter("rpfromCode", fromCode));
                paremeters.Add(new ReportParameter("rptoCode", toCode));                      
                if ("x".Equals(departmentId))
                    paremeters.Add(new ReportParameter("rpDepartmentName", ""));
                else
                paremeters.Add(new ReportParameter("rpDepartmentName", _departmentService.GetById(departmentId).Name));             
                LocalReport report = new LocalReport();
                report.LoadReportDefinition(reportDefinition);
                report.DataSources.Add(new ReportDataSource("EmployeeDetailDataSet", employeeDetail));
               report.SetParameters(paremeters);
                byte[] pdf = report.Render("PDF");
                return File(pdf, "application/pdf");
            }
            return View();
        }

    }
}
