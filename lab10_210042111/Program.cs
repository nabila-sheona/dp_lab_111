using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10_210042111
{
    internal class Program
    {
        static void Main(string[] args)
        {


            BankAccount account1 = new BankAccount("acc001", 1000);
            BankAccount account2 = new BankAccount("acc002", 500);

            BankOperationExecutor executor = new BankOperationExecutor();

            // Create accounts
            ICommand createAccount1 = new CreateAccountCommand(account1);
            executor.SetCommand(createAccount1, $"Created account {account1.AccountNumber} with initial balance {account1.Balance}");
            executor.ExecuteCommand();

            ICommand createAccount2 = new CreateAccountCommand(account2);
            executor.SetCommand(createAccount2, $"Created account {account2.AccountNumber} with initial balance {account2.Balance}");
            executor.ExecuteCommand();

            // Deposit to account1
            ICommand deposit = new DepositCommand(account1, 200);
            executor.SetCommand(deposit, $"Deposited 200 to account {account1.AccountNumber}");
            executor.ExecuteCommand();

            // Withdraw from account1
            ICommand withdraw = new WithdrawCommand(account1, 150);
            executor.SetCommand(withdraw, $"Withdrew 150 from account {account1.AccountNumber}");
            executor.ExecuteCommand();

            // Transfer from account1 to account2
            ICommand transfer = new TransferCommand(account1, account2, 300);
            executor.SetCommand(transfer, $"Transferred 300 from account {account1.AccountNumber} to {account2.AccountNumber}");
            executor.ExecuteCommand();

            // Print current balances
            account1.GetBalance();
            account2.GetBalance();

            // Print command history
            executor.PrintCommandHistory();
            Console.ReadKey();



        }
    }
}
