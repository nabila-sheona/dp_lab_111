using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab06_210042111
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //using email

            INotify emailNotification = new SendEmail();
            NotificationService emailService = new NotificationService(emailNotification);
            emailService.SendNotification("Hello, this is your email message!", "athenacc@gmail.com");
            
            
            //using sms

            INotify smsNotification = new SendSMS();
            NotificationService smsService=new NotificationService(smsNotification);
            smsService.SendNotification("Notification sent by sms", "+8801456789012");


            // using postal
            PostalNotification postalNotification = new PostalNotification();
            INotify postalNotificationAdapter = new PostalNotificationAdapter(postalNotification, "5 siddeshawari road", 1217);
            NotificationService postalService = new NotificationService(postalNotificationAdapter);
            postalService.SendNotification("Sent by postal message!", "Sheona");

            Console.ReadKey();

        }
    }
}
