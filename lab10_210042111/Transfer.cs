using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10_210042111
{
    public class Transfer:ICommand
    {
        public BankAccount Account { get; }
        public BankAccount Account2 { get; }
        public double amount;
        public bool done;

        public Transfer(BankAccount account, BankAccount account2, double amount)
        {
            Account = account;
            Account2 = account2;
            this.amount = amount;
        }

        public bool Execute()
        {
           
            Account.Withdraw(amount);
            if (amount > Account.balance)
            {
                done = false;
               
                return false;

            }
            else
            {
                Account2.Deposit(amount);
                return true;
            }
        }
    }
}
