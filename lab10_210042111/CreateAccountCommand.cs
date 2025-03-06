
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10_210042111
{
    public class CreateAccountCommand : ICommand
    {
        public BankAccount Account { get; }
        public CreateAccountCommand(BankAccount account)
        {
            Account = account;
        }

        public bool Execute()
        {
            if (Account.Balance < 0)
            {
                Console.WriteLine("Initial balance cannot be negative.");
                return false;
            }
            Console.WriteLine($"[Write Model] Account {Account.AccountNumber} created with balance {Account.Balance}.");
            EventBus.Publish(new AccountCreatedEvent(Account.AccountNumber, Account.Balance));
            return true;
        }
    }


}
