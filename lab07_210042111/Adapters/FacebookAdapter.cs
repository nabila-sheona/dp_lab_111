using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab07_210042111
{
    public class FacebookAdapter : ISocialMediaAdapter
    {
        private FacebookApi facebookApi;

        public FacebookAdapter()
        {
            facebookApi = new FacebookApi();
        }

        public List<Notification> FetchNotifications()
        {
            var facebookNotifications = facebookApi.GetNotifications();
            var notifications = new List<Notification>();

            foreach (var facebook in facebookNotifications)
            {
                notifications.Add(new Notification
                {
                    Platform = "Facebook",
                    Content = facebook.Message,
                    IsRead = facebook.Seen
                });
            }
            return notifications;
        }

        public void MarkAsRead(string notificationId)
        {
            facebookApi.MarkNotificationAsSeen(notificationId);
        }

        public void DeleteNotification(string notificationId)
        {
            facebookApi.RemoveNotification(notificationId);
        }
    }

}
