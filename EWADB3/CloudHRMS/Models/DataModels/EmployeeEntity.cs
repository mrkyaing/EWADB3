using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudHRMS.Models.DataModels
{
    [Table("Employee")]
    public class EmployeeEntity: BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOE { get; set; }
        public DateTime? DOR { get; set; }
        public decimal BasicSalary { get; set; }
        public string Gender { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
    }
}
