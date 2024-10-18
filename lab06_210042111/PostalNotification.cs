using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab06_210042111
{
    public class PostalNotification
    {
        string message;
        public void PostalSendNotification(string msg, string recipient, string address, int postalCode)
        {
            message = msg;
            Console.WriteLine($"Sending Postal Mail to {recipient}, {address}, " + postalCode + $", : {message}");

        }

    }
}
