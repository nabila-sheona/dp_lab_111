using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10_210042111
{
    public class DepositEvent : IEvent
    {
        public DateTime Timestamp { get; }
        public string AccountNumber { get; }
        public double Amount { get; }

        public DepositEvent(string accountNumber, double amount)
        {
            Timestamp = DateTime.Now;
            AccountNumber = accountNumber;
            Amount = amount;
        }
    }
}
