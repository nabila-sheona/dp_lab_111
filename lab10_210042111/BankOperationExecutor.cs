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
        public string details;

        private readonly Dictionary<ICommand, string> commandHistory = new Dictionary<ICommand, string>();
        public void SetCommand(ICommand command, string details) {
            this.command = command;
            this.details = details;
            
        }

        

        public void ExecuteCommand()
        {

           bool val= command.Execute();
            if (val)
            { commandHistory.Add(command, details); }
        }

        public void PrintCommandStack()
        {
            foreach(var entity in commandHistory)
            {
                Console.WriteLine(entity);
            }
        }
    }
}
