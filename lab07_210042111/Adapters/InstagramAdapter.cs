using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab07_210042111
{
    public class InstagramAdapter : ISocialMediaAdapter
    {
        private InstagramApi instagramApi;

        public InstagramAdapter()
        {
            instagramApi = new InstagramApi();
        }

        public List<Notification> FetchNotifications()
        {
            var instagramNotifications = instagramApi.GetStories();
            var notifications = new List<Notification>();

            foreach (var story in instagramNotifications)
            {
                notifications.Add(new Notification
                {
                    Platform = "Instagram",
                    Content = story.Caption,
                    IsRead = story.Seen
                });
            }
            return notifications;
        }

        public void MarkAsRead(string notificationId)
        {
            if (!string.IsNullOrEmpty(notificationId))
            {
                instagramApi.MarkStoryAsSeen(notificationId);
            }
        }

        public void DeleteNotification(string notificationId)
        {
            if (!string.IsNullOrEmpty(notificationId))
            {
                instagramApi.RemoveStory(notificationId);
            }
        }
    }
}
