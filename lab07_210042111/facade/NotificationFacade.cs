using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab07_210042111
{

        public class NotificationFacade
        {
            private List<ISocialMediaAdapter> adapters;

            public NotificationFacade()
            {
                adapters = new List<ISocialMediaAdapter>();
            }

            public void AddAdapter(ISocialMediaAdapter adapter)
            {
                adapters.Add(adapter);
            }

            public List<Notification> GetAllNotifications()
            {
                var allNotifications = new List<Notification>();
                foreach (var adapter in adapters)
                {
                    allNotifications.AddRange(adapter.FetchNotifications());
                }
                return allNotifications;
            }

            public void MarkNotificationAsRead(string platform, string notificationId)
            {
                ISocialMediaAdapter adapter = null;

                for (int i = 0; i < adapters.Count; i++)
                {
                    if (platform == "Twitter" && adapters[i] is TwitterAdapter)
                    {
                        adapter = adapters[i];
                        break;
                    }
                    else if (platform == "Facebook" && adapters[i] is FacebookAdapter)
                    {
                        adapter = adapters[i];
                        break;
                    }
                    else if (platform == "LinkedIn" && adapters[i] is LinkedInAdapter)
                    {
                        adapter = adapters[i];
                        break;
                    }
                
                    else if (platform == "Instagram" && adapters[i] is InstagramAdapter)
                    {
                        adapter = adapters[i];
                        break;
                     }
            }

                if (adapter != null)
                {
                    adapter.MarkAsRead(notificationId);
                }
            }

            public void DeleteNotification(string platform, string notificationId)
            {
                ISocialMediaAdapter adapter = null;

                for (int i = 0; i < adapters.Count; i++)
                {
                    if (platform == "Twitter" && adapters[i] is TwitterAdapter)
                    {
                        adapter = adapters[i];
                        break;
                    }
                    else if (platform == "Facebook" && adapters[i] is FacebookAdapter)
                    {
                        adapter = adapters[i];
                        break;
                    }
                    else if (platform == "LinkedIn" && adapters[i] is LinkedInAdapter)
                    {
                        adapter = adapters[i];
                        break;
                    }
                    else if (platform == "Instagram" && adapters[i] is InstagramAdapter)
                    {
                       adapter = adapters[i];
                        break;
                     }
            }

                if (adapter != null)
                {
                    adapter.DeleteNotification(notificationId);
                }
            }
        }

    
}