using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10_210042111
{
    public class InterestCalculatedEvent : IEvent
    {
        public DateTime Timestamp { get; }
        public string AccountNumber { get; }
        public double InterestAmount { get; }

        public InterestCalculatedEvent(string accountNumber, double interestAmount)
        {
            Timestamp = DateTime.Now;
            AccountNumber = accountNumber;
            InterestAmount = interestAmount;
        }
    }
}
