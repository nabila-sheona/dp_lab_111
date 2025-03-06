
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10_210042111
{

    public class TransferCommand : ICommand
    {
        public BankAccount FromAccount { get; }
        public BankAccount ToAccount { get; }
        private double amount;
        public TransferCommand(BankAccount fromAccount, BankAccount toAccount, double amount)
        {
            FromAccount = fromAccount;
            ToAccount = toAccount;
            this.amount = amount;
        }
        public bool Execute()
        {
            if (FromAccount.Withdraw(amount))
            {
                ToAccount.Deposit(amount);
                Console.WriteLine($"[Write Model] Transferred {amount} from {FromAccount.AccountNumber} to {ToAccount.AccountNumber}.");
                EventBus.Publish(new TransferEvent(FromAccount.AccountNumber, ToAccount.AccountNumber, amount));
                return true;
            }
            return false;
        }
    }

}
