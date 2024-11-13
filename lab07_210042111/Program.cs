using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab07_210042111
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var aggregator = new NotificationFacade();

            aggregator.AddAdapter(new TwitterAdapter());
            aggregator.AddAdapter(new FacebookAdapter());
            aggregator.AddAdapter(new LinkedInAdapter());
            aggregator.AddAdapter(new InstagramAdapter());


            var notifications = aggregator.GetAllNotifications();
            foreach (var notification in notifications)
            {
                Console.WriteLine($"[{notification.Platform}] {notification.Content} (Read: {notification.IsRead})");
            }


            aggregator.MarkNotificationAsRead("Twitter", "1");


            aggregator.DeleteNotification("Facebook", "1");


            aggregator.MarkNotificationAsRead("LinkedIn", "1");


            aggregator.DeleteNotification("Instagram", "2");


            Console.ReadKey();
        }
    }
}
