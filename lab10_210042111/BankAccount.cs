using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10_210042111
{
    public class BankAccount
    {
        public string AccountNumber { get; }
        public double balance;

        public BankAccount(string accountNumber, double balance)
        {
            AccountNumber = accountNumber;
            this.balance = balance;
        }
        public void Deposit(double amount)
        {
            balance += amount;

        }
        public bool Withdraw(double amount)
        {
            if (amount < balance)
            {
                balance -= amount;

                Console.WriteLine($"withdraw {amount} from {AccountNumber}");
                return true;
            }

            else
            {
                Console.WriteLine("Insufficient amount.");
                return false;
            }


        }
       

        public void GetBalance()
        {
            Console.WriteLine($"Account {AccountNumber} balance: {balance}.");
        }

    }
}
