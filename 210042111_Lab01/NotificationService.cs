using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _210042111_Lab01
{
    public enum NotificationType
    {
        SMS,
        Email
            //add more facilites as per the system
    }

    public class NotificationService
    {
        public static void sendNotification(string message, User recipient, NotificationType notificationType)
        {
            switch (notificationType)
            {
                case NotificationType.SMS:
                    sendSMS(message, recipient);
                    break;
                case NotificationType.Email:
                    sendEmail(message, recipient);
                    break;
                default:
                    throw new ArgumentException("Invalid notification type.");
            }

            //add more facilites as per the enum
        }

        private static void sendSMS(string message, User recipient)
        {
            Console.WriteLine($"SMS to : {message}");
        }

        private static void sendEmail(string message, User recipient)
        {
            Console.WriteLine($"SMS to : {message}");
        }

      //add more functions if more methods of sending noti. is added to the system
    }

}
