using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab06_210042111
{
    public class SendSMS:INotify
    {
        public void SendNotification(string message, string recipient)
        {
            Console.WriteLine($"Sending phone to {recipient}: {message}");
        }
    }
}
