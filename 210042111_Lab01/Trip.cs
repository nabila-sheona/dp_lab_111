using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace _210042111_Lab01
{
    public class Trip
    {
        public int id { get; set; }
        public string pickupLocation { get; set; }
        public string dropOffLocation { get; set; }
        public RideType rideType { get; set; }
        public double fare { get; set; }
        public Driver driver { get;  set; }
        public Rider rider { get;  set; }
        public bool isCompleted { get;  set; } = false;
        public Admin admin { get; set; }

        public Trip(int id, Rider rider, RideType rideType, double fare)
        {
            this.id = id;
            this.rider = rider;
            
            this.rideType = rideType;
            this.fare = fare;
           
        }


        public bool callTrip(Admin admin, Rider rider, string pickupLocation, string dropOffLocation)
        {
            this.admin = admin;
            this.pickupLocation= pickupLocation;
            this.dropOffLocation= dropOffLocation;
            if (admin.assignTrip(this, pickupLocation) == true)
            {
                startTrip(rider);
                completeTrip(rider);
                return true;
               
            }
            else
            {
                Console.WriteLine($"Trip {this} was cancelled due to no available driver.");
                return false;
            }
   
        }
        public void assignDriver(Driver driver, Admin admin)
        {
           
               this.driver = driver;
            driver.isAvailable = false; 
            Console.WriteLine($"Driver {driver.name} assigned to Trip {id}.");
            driver.acceptRide(this, admin);
        }

      

        
        public void paymentType(Rider rider)
        {
            Console.WriteLine("Choose a new payment method:");
            Console.WriteLine("1. Credit Card");
            Console.WriteLine("2. Digital Wallet");
            Console.WriteLine("3. Bkash");

            int newChoice = Convert.ToInt32(Console.ReadLine());
            if (newChoice == 1)
            {
                Console.WriteLine("Enter card number:");
                string cardNumber = Console.ReadLine();

                Console.WriteLine("Enter cardholder name:");
                string cardHolderName = Console.ReadLine();

                rider.changePaymentMethod(new CreditCard(cardNumber, cardHolderName));
            }
            else if (newChoice == 2)
            {
                Console.WriteLine("Enter wallet number:");
                string WalletId = Console.ReadLine();

                rider.changePaymentMethod(new DigitalWallet(WalletId));
            }
            else if (newChoice == 3)
            {
                Console.WriteLine("Enter phone number:");
                string phone = Console.ReadLine();

                rider.changePaymentMethod(new Bkash(phone));
            }
        }


        public void startTrip(Rider rider)
        {
            paymentType(rider);
     

            Console.WriteLine($"Trip {id} started from {pickupLocation} to {dropOffLocation}.");

         
        }
        public void completeTrip(Rider rider)
        {
            Console.WriteLine("Do you want to change your payment method? (y/n)");
            string change = Console.ReadLine();

            if (change.ToLower() == "y")
            {
                paymentType(rider);
            }

                isCompleted = true;


            Console.WriteLine($"Trip {id} completed.");


            driver.isAvailable = true;
            driver.updateLocation(admin, dropOffLocation);
        }
      
        public void callRate()
        {
            Console.WriteLine("rider give the rate between 1 and 5 else default rate will go");
            double rate = Convert.ToDouble(Console.ReadLine());
            if (rate >= 1 && rate <= 5)
            {
                afterTripRider(rate);
            }

            Console.WriteLine("driver give the rate between 1 and 5 else default rate will go");
            rate = Convert.ToDouble(Console.ReadLine());
            if (rate >= 1 && rate <= 5)
            {
                ratingRider(rate);
            }

        }

        public void afterTripRider(double rate)
        {
            rider.makePayment(this, rate);
        }

        public void ratingRider(double rate)
        {
            if (isCompleted)
            {
                driver.rateRider(rider, rate);
            }
        }
    }
}
