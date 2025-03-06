using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10_210042111
{
    public class AccountCreatedEvent : IEvent
    {
        public DateTime Timestamp { get; }
        public string AccountNumber { get; }
        public double InitialBalance { get; }

        public AccountCreatedEvent(string accountNumber, double initialBalance)
        {
            Timestamp = DateTime.Now;
            AccountNumber = accountNumber;
            InitialBalance = initialBalance;
        }
    }

}
