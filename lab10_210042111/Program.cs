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
            BankAccount account = new BankAccount("nabila111", 1000);
            BankAccount account2 = new BankAccount("iqra09", 500);

            BankOperationExecutor bankOperationExecutor = new BankOperationExecutor();
            //create
            ICommand createAccount = new CreateAccountCommand(account);
            string userInfo = $"Account name {account.AccountNumber} initial amount: {account.balance}.";
            bankOperationExecutor.SetCommand(createAccount, userInfo);
            bankOperationExecutor.ExecuteCommand();

            account.GetBalance();

            ICommand createAccount2 = new CreateAccountCommand(account2);
            string userInfo2 = $"Account name {account2.AccountNumber} initial amount: {account2.balance}.";
            bankOperationExecutor.SetCommand(createAccount2, userInfo2);
            bankOperationExecutor.ExecuteCommand();

            account2.GetBalance();



            //deposit
            double depositAmount = 100;
            ICommand deposit=new DepositCommand(account, depositAmount);
            string userInfo3 = $"Account name {account.AccountNumber} added amount: {depositAmount}.";
            bankOperationExecutor.SetCommand(deposit, userInfo3);
            bankOperationExecutor.ExecuteCommand();
            account.GetBalance();

            //withdraw
            double withdrawAmount = 100;
            ICommand withdraw = new WithdrawCommand(account, withdrawAmount);
            string userInfo4 = $"Account name {account.AccountNumber} removed amount: {withdrawAmount}.";
            bankOperationExecutor.SetCommand(withdraw, userInfo4);
            bankOperationExecutor.ExecuteCommand();
         


            double withdrawAmount2 = 1000;
            ICommand withdraw2 = new WithdrawCommand(account2, withdrawAmount2);
            string userInfo5 = $"Account name {account2.AccountNumber} removed amount: {withdrawAmount2}.";
            
           bankOperationExecutor.SetCommand(withdraw2, userInfo5);
           bankOperationExecutor.ExecuteCommand();

            double transferAmount = 100;
            ICommand transfer = new Transfer(account, account2, transferAmount);
            string userInfo6 = $"Account name {account.AccountNumber} sent amount: {transferAmount} Account name {account2.AccountNumber} recieved amount: {transferAmount}.";

            bankOperationExecutor.SetCommand(transfer, userInfo6);
            bankOperationExecutor.ExecuteCommand();
            account.GetBalance();
            account2.GetBalance();



            bankOperationExecutor.PrintCommandStack();

            Console.ReadKey();



        }
    }
}
