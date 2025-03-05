using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace lab10_210042111
{
    public class DepositCommand: ICommand
    {
        public BankAccount Account { get;}
        private double amount;

        public DepositCommand(BankAccount account, double amount)
        {
            Account = account;
            this.amount = amount;
        }
        public bool Execute()
        {
            Account.Deposit(amount);
            return true;
        }
    }
}
