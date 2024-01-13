namespace Day4;

class Program
{
    static void Main(string[] args)
    {
        ICreditCard creditCard = new BankAccount()
        {
            Name = "U Ba",
            Type = BankAccountType.SAVING.ToString(),
            AccountNo = "00112233445566",
            Balance = 1000,
            OpenedDate = DateTime.Now
        };
        var amout = creditCard.GetSDGExchangeRate(1500);
        Console.WriteLine(amout);
        Console.WriteLine(creditCard.GetUSDExchangeRate(10));
        Staff s = new Staff()
        {
            Name = "Min min",
            Address = "YGN",
            DOB = Convert.ToDateTime("1993-10-10"),
            DOE = Convert.ToDateTime("2021-10-10"),
            BaseSalary = 300000,
            Id = "s001"
        };
        IPayrollService payrollService = new PayrollService();
        decimal payamout = payrollService.CalculatePayroll(s, 20);
        decimal bonus = payrollService.CalculateBonus(s);
        decimal benefit = payrollService.Benefit(20000);
        decimal deduction = payrollService.Deduction(500);
        decimal NetPay = payamout + bonus + benefit - deduction;
        s.ShowInfo();
        Console.WriteLine(creditCard);
        Console.WriteLine($"Your Net Pay of This month {NetPay}");
    }
}
