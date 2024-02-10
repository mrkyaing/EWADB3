using System.ComponentModel.DataAnnotations;

namespace CloudHRMS.Models.ViewModels
{
    public class EmployeeViewModel
    {
        public string Id { get; set; }//edit/update,delete
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public DateTime DOE { get; set; }
        public DateTime? DOR { get; set; }
        [Required]
        public decimal BasicSalary { get; set; }
        [Required]
        public string Gender { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
    }
}
