using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day4
{
    public class PayrollService : IPayrollService
    {
        public decimal Benefit(decimal amount)
        {
            return amount;
        }

        public decimal CalculateBonus(Staff staff)
        {
           //over 3 years 3% of Basic Salary
           //over 5 years 5% of Basic Salary
           //over 7 years 7% of Basic Salary
           //over 10++ years 10% of Basic Salary
           decimal result=0;
           int  currentYear=DateTime.Now.Year;
           if(currentYear-staff.DOE.Year>=10){
            result=(staff.BaseSalary/100)*10m;
           }
            else if(currentYear-staff.DOE.Year>=7){
            result=(staff.BaseSalary/100)*7m;
           }
            else if(currentYear-staff.DOE.Year>=5){
            result=(staff.BaseSalary/100)*5m;
           }
            else if(currentYear-staff.DOE.Year>=3){
            result=(staff.BaseSalary/100)*3m;
           }
           return result;
        }

        public decimal CalculatePayroll(Staff staff,decimal AttendanceDays)
        {
            decimal result=0;
            result=(staff.BaseSalary/30)*AttendanceDays;
            return result;
        }

        public decimal Deduction(decimal amount)
        {
           return amount;
        }
        
    }
}