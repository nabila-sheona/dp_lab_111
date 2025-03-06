using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10_210042111
{
    public class AccountReadRepository
    {
        public Dictionary<string, double> AccountBalances { get; } = new Dictionary<string, double>();
        public List<string> TransactionHistory { get; } = new List<string>();

        public void UpdateBalance(string accountNumber, double balance)
        {
            AccountBalances[accountNumber] = balance;
        }

        public void AddTransaction(string transaction)
        {
            TransactionHistory.Add(transaction);
        }

        public void PrintBalances()
        {
            Console.WriteLine("\n[Read Model] Account Balances:");
            foreach (var item in AccountBalances)
            {
                Console.WriteLine($"Account {item.Key}: {item.Value}");
            }
        }

        public void PrintTransactionHistory()
        {
            Console.WriteLine("\n[Read Model] Transaction History:");
            foreach (var transaction in TransactionHistory)
            {
                Console.WriteLine(transaction);
            }
        }
    }
}
