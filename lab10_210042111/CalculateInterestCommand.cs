
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10_210042111
{
    public class CalculateInterestCommand : ICommand
    {
        public BankAccount Account { get; }
        private double interestRate;
        public CalculateInterestCommand(BankAccount account, double interestRate)
        {
            Account = account;
            this.interestRate = interestRate;
        }
        public bool Execute()
        {
            if (interestRate <= 0)
            {
                Console.WriteLine("Interest rate must be positive.");
                return false;
            }
            double interest = Account.Balance * interestRate;
            Account.Deposit(interest);
            Console.WriteLine($"Interest of {interest} added to account {Account.AccountNumber}.");
            EventBus.Publish(new InterestCalculatedEvent(Account.AccountNumber, interest));
            return true;
        }
    }
}
