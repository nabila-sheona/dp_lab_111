using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10_210042111
{
    public class TransferEvent : IEvent
    {
        public DateTime Timestamp { get; }
        public string FromAccount { get; }
        public string ToAccount { get; }
        public double Amount { get; }

        public TransferEvent(string fromAccount, string toAccount, double amount)
        {
            Timestamp = DateTime.Now;
            FromAccount = fromAccount;
            ToAccount = toAccount;
            Amount = amount;
        }
    }

}
