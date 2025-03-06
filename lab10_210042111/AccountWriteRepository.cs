using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10_210042111
{
    public class AccountWriteRepository
    {
        private readonly Dictionary<string, BankAccount> accounts = new Dictionary<string, BankAccount>();

        public void Add(BankAccount account)
        {
            if (!accounts.ContainsKey(account.AccountNumber))
                accounts.Add(account.AccountNumber, account);
        }

        public BankAccount Get(string accountNumber)
        {
            accounts.TryGetValue(accountNumber, out BankAccount account);
            return account;
        }
    }

}
