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

            Driver driver1 = new Driver(1, "Navan", "Sedan", NotificationType.Email, "12 Motijheel");
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
           
            rider1.RequestRide("123 Motijheel", "56 Siddeshawari Road", carpool, 10.0, 101, admin);

          
            Console.WriteLine("-------------------------------------------------");


            Console.WriteLine("-------------------trip2----------------------");

            rider2.RequestRide("Bailey Road", "Gulshan Avenue", luxuryRide, 12.0, 102, admin);

         


            Console.WriteLine("-------------------------------------------------");

            Console.WriteLine("-----------------------press key to see details--------------------------");
            Console.ReadKey();

            admin.tripHistory();

            Console.WriteLine("-----------------------press key to continue--------------------------");
            Console.ReadKey();

            driver2.updateLocation(admin, "123 Motijheel");

            Console.WriteLine("-------------------trip3----------------------");

           rider1.RequestRide("123 Motijheel", "56 Siddeshawari Road", carpool, 10.0, 103, admin);

        

            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("-------------------trip4----------------------");

            rider2.RequestRide("Bailey Road", "Gulshan Avenue", luxuryRide, 12.0, 104, admin);


      


            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("-----------------------press key to see details--------------------------");

            Console.ReadKey();
            admin.seeRiders();
            admin.seeDrivers();
            admin.tripHistory();

            Console.WriteLine("-----------------------press key to end the program--------------------------");
            Console.ReadKey();
            //all the locations are set to bd places
          
        }
    }

    public abstract class User
    {
       string name { get; }
       NotificationType notificationMethod { get; }
    }


}