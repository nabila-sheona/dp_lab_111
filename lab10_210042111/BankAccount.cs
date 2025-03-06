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

        public bool Deposit(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Deposit amount must be positive.");
                return false;
            }
            Balance += amount;
            Console.WriteLine($"{amount} deposited to {AccountNumber}. New Balance: {Balance}");
            return true;
        }

        public bool Withdraw(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Withdrawal amount must be positive.");
                return false;
            }
            if (amount > Balance)
            {
                Console.WriteLine("Insufficient funds.");
                return false;
            }
            Balance -= amount;
            Console.WriteLine($"{amount} withdrawn from {AccountNumber}. New Balance: {Balance}");
            return true;
        }
    }
}
