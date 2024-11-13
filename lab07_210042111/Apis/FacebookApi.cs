using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab07_210042111
{
    public class FacebookApi
    {
        public List<(string Id, string Message, bool Seen)> GetNotifications()
        {
            return new List<(string, string, bool)>
        {
            ("1", "Facebook Notification 1", false),
            ("2", "Facebook Notification 2", true)
        };
        }

        public void MarkNotificationAsSeen(string notificationId)
        {
            Console.WriteLine($"Facebook: Marking notification {notificationId} as seen.");
        }

        public void RemoveNotification(string notificationId)
        {
            Console.WriteLine($"Facebook: Removing notification {notificationId}.");
        }
    }

}
