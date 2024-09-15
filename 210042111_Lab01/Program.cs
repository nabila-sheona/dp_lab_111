using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _210042111_Lab01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Admin admin = new Admin(11, "Sheona", "Admin");

            Driver driver1 = new Driver(1, "Navan", "Sedan", NotificationType.Email, "12 Manhattan");
            Driver driver2 = new Driver(2, "Shaily", "SUV", NotificationType.SMS, "Bailey Road");
            Driver driver3 = new Driver(2, "Farena", "SUV", NotificationType.SMS, "Bailey Road");

            admin.manageDriver(driver1, true);
            admin.manageDriver(driver2, true);
            admin.manageDriver(driver3, true);

            RideType carpool = new Carpool();
            RideType luxuryRide = new LuxuryRide();

            Rider rider1 = new Rider(1, "Lourena Chowdhury", NotificationType.Email)
            {
                preferredPaymentMethod = new CreditCard { cardNumber = "1234-5678-9012-3456", cardHolderName = "Lourena Chowdhury" }
            };

            Rider rider2 = new Rider(2, "Athena", NotificationType.SMS)
            {
                preferredPaymentMethod = new DigitalWallet { walletId = "1234-5678-9012-3456" }
            };
            admin.manageRider(rider1, true);
            admin.manageRider(rider2, true);
            Console.WriteLine("-------------------trip1----------------------");
           
            Trip trip1 = rider1.RequestRide("123 Manhattan", "56 Elmhurst St", carpool, 10.0, 101);


            if (trip1.callTrip(admin, rider2) == true)
            {
                trip1.afterTripRider(5.0);

                trip1.ratingRider(5.0);

            }

            Console.WriteLine("-------------------------------------------------");


            Console.WriteLine("-------------------trip2----------------------");

            Trip trip2 = rider2.RequestRide("Bailey Road", "Gulshan Avenue", luxuryRide, 10.0, 102);
            if (trip2.callTrip(admin, rider2) == true)
            {
                trip2.afterTripRider(5.0);

                trip2.ratingRider(5.0);

            }

            Console.WriteLine("-------------------------------------------------");

            Console.WriteLine("-----------------------press key to see details--------------------------");
            Console.ReadKey();

            admin.tripHistory();

            Console.WriteLine("-----------------------press key to continue--------------------------");
            Console.ReadKey();

            driver2.updateLocation(admin, "123 Manhattan");

            Console.WriteLine("-------------------trip3----------------------");

            Trip trip3 = rider1.RequestRide("123 Manhattan", "56 Elmhurst St", carpool, 10.0, 103);
           


            if (trip3.callTrip(admin, rider2) == true)
            {
                trip3.afterTripRider(4.0);

                trip3.ratingRider(4.0);

            }

            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("-------------------trip4----------------------");

            Trip trip4 = rider2.RequestRide("Bailey Road", "Gulshan Avenue", luxuryRide, 10.0, 104);

            if (trip4.callTrip(admin, rider2) == true)
            {
                trip4.afterTripRider(5.0);

                trip4.ratingRider(5.0);

            }

            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("-----------------------press key to see details--------------------------");

            Console.ReadKey();
            admin.seeRiders();
            admin.seeDrivers();
            admin.tripHistory();

            Console.WriteLine("-----------------------press key to end the program--------------------------");
            Console.ReadKey();
          
        }
    }

    public interface User
    {
        string name { get; }
        NotificationType notificationMethod { get; }
    }


}