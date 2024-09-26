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
        private IPaymentMethod paymentMethod;
        public Trip(int id, Rider rider, RideType rideType, double fare)
        {
            this.id = id;
            this.rider = rider;
            
            this.rideType = rideType;
            this.fare = fare;
           
        }

        private void SetPaymentType()
        {
            Console.WriteLine("Choose a payment method:");
            Console.WriteLine("1. Credit Card");
            Console.WriteLine("2. Digital Wallet");
            Console.WriteLine("3. Bkash");

            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter card number:");
                    string cardNumber = Console.ReadLine();
                    Console.WriteLine("Enter cardholder name:");
                    string cardHolderName = Console.ReadLine();
                    paymentMethod = new CreditCard(cardNumber, cardHolderName);
                    break;
                case 2:
                    Console.WriteLine("Enter wallet number:");
                    string walletId = Console.ReadLine();
                    paymentMethod = new DigitalWallet(walletId);
                    break;
                case 3:
                    Console.WriteLine("Enter phone number:");
                    string phone = Console.ReadLine();
                    paymentMethod = new Bkash(phone);
                    break;
                default:
                    Console.WriteLine("Invalid choice, no payment method selected.");
                    break;
            }
        }

        private void ProcessPayment()
        {
            if (paymentMethod != null)
            {
                paymentMethod.processPayment(fare);
            }
            else
            {
                Console.WriteLine("No payment method selected.");
            }
        }

        public bool callTrip(Admin admin, Rider rider, string pickupLocation, string dropOffLocation)
        {
            this.admin = admin;
            this.pickupLocation= pickupLocation;
            this.dropOffLocation= dropOffLocation;
            if (admin.assignTrip(this, pickupLocation) == true)
            {
                startTrip();
                completeTrip();
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



    

     

        public void startTrip()
        {
            SetPaymentType();
            Console.WriteLine($"Trip {id} started from {pickupLocation} to {dropOffLocation}.");
           
        }

        

     
        public void completeTrip()
        {
            Console.WriteLine("Do you want to change your payment method? (y/n)");
            string change = Console.ReadLine();

            if (change.ToLower() == "y")
            {
                 SetPaymentType();
            }

                isCompleted = true;


            Console.WriteLine($"Trip {id} completed.");


            driver.isAvailable = true;
            driver.updateLocation(admin, dropOffLocation);
            ProcessPayment();
        }

        public void callRate()
        {
            double riderRate = GetValidRating("rider");
            if (riderRate >= 1 && riderRate <= 5)
            {
                afterTripRider(riderRate);
            }

            double driverRate = GetValidRating("driver");
            if (driverRate >= 1 && driverRate <= 5)
            {
                ratingRider(driverRate);
            }
        }

      
        private double GetValidRating(string role)
        {
            double rating;
            while (true)
            {
                Console.WriteLine($"{role} give the rate between 1 and 5 else default rate will go:");
                string input = Console.ReadLine();

              
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Input cannot be empty. Please enter a rating.");
                    continue;
                }

                
                if (double.TryParse(input, out rating))
                {
                    if (rating >= 1 && rating <= 5)
                    {
                        return rating;
                    }
                    else
                    {
                        Console.WriteLine("Rating must be between 1 and 5. Please try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a numeric rating.");
                }
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
