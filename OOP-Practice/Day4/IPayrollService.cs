
namespace Day4
{
    public interface IPayrollService
    {
        decimal CalculatePayroll(Staff staff,decimal AttendanceDays);
        decimal CalculateBonus(Staff staff);
        decimal Deduction(decimal amount);
        decimal Benefit(decimal amount);
    }
}