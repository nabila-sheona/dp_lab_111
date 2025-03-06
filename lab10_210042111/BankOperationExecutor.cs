using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace lab10_210042111
{
    public class BankOperationExecutor
    {
        private ICommand command;
        private string details;
        private readonly List<string> commandHistory = new List<string>();

        public void SetCommand(ICommand command, string details)
        {
            this.command = command;
            this.details = details;
        }

        public void ExecuteCommand()
        {
            if (command.Execute())
            {
                commandHistory.Add(details);
            }
        }

        public void PrintCommandHistory()
        {
            Console.WriteLine("\nCommand History:");
            foreach (var entry in commandHistory)
            {
                Console.WriteLine(entry);
            }
        }
    }
}
