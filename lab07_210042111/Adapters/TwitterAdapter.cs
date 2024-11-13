using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab07_210042111
{
    public class TwitterAdapter: ISocialMediaAdapter
    {
        private TwitterApi twitterApi;

        public TwitterAdapter()
        {
            twitterApi = new TwitterApi();
        }

        public List<Notification> FetchNotifications()
        {
            var twitterNotifications = twitterApi.GetTweets();
            var notifications = new List<Notification>();

            foreach (var tweet in twitterNotifications)
            {
                notifications.Add(new Notification
                {
                    Platform = "Twitter",
                    Content = tweet.Content,
                    IsRead = tweet.IsRead
                });
            }
            return notifications;
        }

        public void MarkAsRead(string notificationId)
        {
            twitterApi.MarkTweetAsRead(notificationId);
        }

        public void DeleteNotification(string notificationId)
        {
            twitterApi.DeleteTweet(notificationId);
        }
    }
}
