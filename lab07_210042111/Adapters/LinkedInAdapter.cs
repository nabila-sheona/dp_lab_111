using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab07_210042111
{
    public class LinkedInAdapter : ISocialMediaAdapter
    {
        private LinkedInApi linkedInApi;

        public LinkedInAdapter()
        {
            linkedInApi = new LinkedInApi();
        }

        public List<Notification> FetchNotifications()
        {
            var linkedInNotifications = linkedInApi.GetUpdates();
            var notifications = new List<Notification>();

            foreach (var update in linkedInNotifications)
            {
                notifications.Add(new Notification
                {
                    Platform = "LinkedIn",
                    Content = update.Message,
                    IsRead = update.Seen
                });
            }
            return notifications;
        }

        public void MarkAsRead(string notificationId)
        {
            
                linkedInApi.MarkUpdateAsSeen(notificationId);
            
        }

        public void DeleteNotification(string notificationId)
        {
            if (!string.IsNullOrEmpty(notificationId))
            {
                linkedInApi.RemoveUpdate(notificationId);
            }
        }
    }
}
