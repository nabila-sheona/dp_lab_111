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
        string paymentStrategy;

        public SetPayment setPayment;
        public Trip(int id, Rider rider, RideType rideType, double fare)
        {
            this.id = id;
            this.rider = rider;
            
            this.rideType = rideType;
            this.fare = fare;
            setPayment = new SetPayment();

        }




        public bool callTrip(Admin admin, Rider rider, string pickupLocation, string dropOffLocation)
        {
            this.admin = admin;
            this.pickupLocation = pickupLocation;
            this.dropOffLocation = dropOffLocation;

            
            paymentMethod = setPayment.SetPaymentType();

            if (paymentMethod == null)
            {
                Console.WriteLine("No payment method was selected. Trip cannot proceed.");
                return false;
            }

            if (admin.assignTrip(this, pickupLocation))
            {
                startTrip();
                completeTrip();
                paymentMethod.processPayment(fare);
                callRate();
                driver.updateLocation(admin, dropOffLocation);

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
           
            Console.WriteLine($"Trip {id} started from {pickupLocation} to {dropOffLocation}.");
           
        }

            
        public void completeTrip()
        {
            Console.WriteLine("Do you want to change your payment method? (y/n)");
            string change = Console.ReadLine();

            if (change.ToLower() == "y")
            {
                 setPayment.SetPaymentType();
            }

                isCompleted = true;


            Console.WriteLine($"Trip {id} completed.");


            driver.isAvailable = true;
           
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
                        return rating; // Valid rating, return it
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
