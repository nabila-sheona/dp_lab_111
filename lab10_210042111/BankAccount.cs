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
        public double Balance { get; private set; }

        public BankAccount(string accountNumber, double initialBalance)
        {
            AccountNumber = accountNumber;
            Balance = initialBalance;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
            Console.WriteLine($"{amount} deposited to {AccountNumber}. New Balance: {Balance}");
        }

        public bool Withdraw(double amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                Console.WriteLine($"{amount} withdrawn from {AccountNumber}. New Balance: {Balance}");
                return true;
            }
            else
            {
                Console.WriteLine("Insufficient funds.");
                return false;
            }
        }

        public void GetBalance()
        {
            Console.WriteLine($"Account {AccountNumber} balance: {Balance}.");
        }
    }
}
