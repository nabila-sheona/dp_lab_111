using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10_210042111
{

    public class WithdrawCommand : ICommand
    {
        public BankAccount Account { get; }
        private double amount;

        public WithdrawCommand(BankAccount account, double amount)
        {
            Account = account;
            this.amount = amount;
        }

        public bool Execute()
        {
            return Account.Withdraw(amount);
        }
    }
}
