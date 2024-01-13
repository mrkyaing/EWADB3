using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day4
{
    public class Staff : IShowDetail
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime DOE { get; set; }
        public DateTime DOB { get; set; }
        public decimal BaseSalary { get; set; }
        public string Address { get; set; }

        public void ShowInfo()
        {
            Console.WriteLine($"Id:{Id}");
            Console.WriteLine($"Name:{Name}");
            Console.WriteLine($"Dote of Employment:{DOE.ToString("yyy-MM-dd")}");
            Console.WriteLine($"Dote of Birth:{DOB.ToString("yyy-MM-dd")}");
            Console.WriteLine($"Base Salary:{BaseSalary} MMK");
            Console.WriteLine($"Address:{Address}");
        }
    }
}