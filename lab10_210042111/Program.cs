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
            // Setup read repository and subscribe to events
            AccountReadRepository readRepo = new AccountReadRepository();
            EventBus.Subscribe((e) =>
            {
                switch (e)
                {
                    case AccountCreatedEvent ace:
                        readRepo.UpdateBalance(ace.AccountNumber, ace.InitialBalance);
                        readRepo.AddTransaction($"Account {ace.AccountNumber} created with balance {ace.InitialBalance} at {ace.Timestamp}");
                        break;
                    case DepositEvent de:
                        double newBalance = readRepo.AccountBalances.ContainsKey(de.AccountNumber)
                            ? readRepo.AccountBalances[de.AccountNumber] + de.Amount
                            : de.Amount;
                        readRepo.UpdateBalance(de.AccountNumber, newBalance);
                        readRepo.AddTransaction($"Deposited {de.Amount} to {de.AccountNumber} at {de.Timestamp}");
                        break;
                    case WithdrawalEvent we:
                        readRepo.AddTransaction($"Withdrew {we.Amount} from {we.AccountNumber} at {we.Timestamp}");
                        break;
                    case TransferEvent te:
                        readRepo.AddTransaction($"Transferred {te.Amount} from {te.FromAccount} to {te.ToAccount} at {te.Timestamp}");
                        break;
                    case InterestCalculatedEvent ie:
                        readRepo.AddTransaction($"Interest {ie.InterestAmount} calculated for {ie.AccountNumber} at {ie.Timestamp}");
                        break;
                }
            });

            // Write repository (for demonstration)
            AccountWriteRepository writeRepo = new AccountWriteRepository();

            BankOperationExecutor executor = new BankOperationExecutor();

            // Create accounts
            BankAccount acc1 = new BankAccount("acc101", 1000);
            BankAccount acc2 = new BankAccount("acc102", 500);
            writeRepo.Add(acc1);
            writeRepo.Add(acc2);

            ICommand createAcc1 = new CreateAccountCommand(acc1);
            executor.SetCommand(createAcc1, $"Created account {acc1.AccountNumber} with initial balance {acc1.Balance}");
            executor.ExecuteCommand();

            ICommand createAcc2 = new CreateAccountCommand(acc2);
            executor.SetCommand(createAcc2, $"Created account {acc2.AccountNumber} with initial balance {acc2.Balance}");
            executor.ExecuteCommand();

            // Deposit command
            ICommand depositCmd = new DepositCommand(acc1, 250);
            executor.SetCommand(depositCmd, $"Deposited 250 to {acc1.AccountNumber}");
            executor.ExecuteCommand();

            // Withdraw command
            ICommand withdrawCmd = new WithdrawCommand(acc1, 100);
            executor.SetCommand(withdrawCmd, $"Withdrew 100 from {acc1.AccountNumber}");
            executor.ExecuteCommand();

            // Transfer command
            ICommand transferCmd = new TransferCommand(acc1, acc2, 300);
            executor.SetCommand(transferCmd, $"Transferred 300 from {acc1.AccountNumber} to {acc2.AccountNumber}");
            executor.ExecuteCommand();

            // Calculate interest on account 2 (5% rate)
            ICommand interestCmd = new CalculateInterestCommand(acc2, 0.05);
            executor.SetCommand(interestCmd, $"Calculated interest for {acc2.AccountNumber} at rate 5%");
            executor.ExecuteCommand();

            // Print command history (write model)
            executor.PrintCommandHistory();

            // Print read model data
            readRepo.PrintBalances();
            readRepo.PrintTransactionHistory();
            Console.ReadKey();



        }
    }
}
