using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab06_210042111
{
    public class NotificationService
    {
        INotify notify;

        public NotificationService(INotify notify)
        {
            this.notify = notify;
        }

        public void SendNotification(string message, string recipient)
        {
            notify.SendNotification(message, recipient);
        }
    }
}
