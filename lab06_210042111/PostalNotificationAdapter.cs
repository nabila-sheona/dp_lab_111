using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace lab06_210042111
{
    public class PostalNotificationAdapter: INotify
    {
        PostalNotification postalNotification;
        string address;
        int postalCode;
        public PostalNotificationAdapter(PostalNotification postalNotification, string address, int postalCode)
        {
           this.postalNotification = postalNotification;

            this.address = address;
            this.postalCode = postalCode;
        }

        public void SendNotification(string message, string recipient)
        {
            postalNotification.PostalSendNotification(message, recipient, address, postalCode);
        }
    }
}
