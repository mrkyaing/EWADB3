using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Day4
{
    public class BankAccount : ICreditCard
    {
        public string AccountNo { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public DateTime OpenedDate { get; set; }
        public string Type { get; set; }
        public decimal GetSDGExchangeRate(decimal amount)
        {
            return amount*1100;
        }

        public decimal GetUSDExchangeRate(decimal amount)
        {
           return amount*33000;
        }

        public override string ToString()
        {
           return $"[Name:{Name}|Type:{Type}|Balance:{Balance}|Number:{AccountNo}]";
        }
    }
    public enum BankAccountType{
        [Description("saving")]
        SAVING,
        [Description("current")]
        CURRENT,
        [Description("special")]
        SPECIAL
    }
}