using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab07_210042111
{
    public interface ISocialMediaAdapter
    {
        List<Notification> FetchNotifications();
        void MarkAsRead(string notificationId);
        void DeleteNotification(string notificationId);

    }
}
