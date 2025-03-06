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
            Console.WriteLine($"Account {Account.AccountNumber} created with balance {Account.Balance}.");
            return true;
        }
    }

}
