using System;

namespace _210042111_Lab01
{
    public class Rider : User
    {
       
       
        public IPaymentMethod preferredPaymentMethod { get; set; }
        public NotificationType notificationMethod { get; set; }

                public Trip trip;

        public Admin admin;
        public Rider(int id, string name, NotificationType notificationMethod)
        {
            this.id = id;
            this.name = name;
            rating = 0.0; 
            totalTrips = 0;
            this.notificationMethod = notificationMethod;
        }


       
        public void RequestRide(string pickupLocation, string dropOffLocation, RideType rideType, double distance, int tripNumber, Admin admin)
        {
            this.admin = admin;
            Console.WriteLine($"{name} is requesting a {rideType.name} ride from {pickupLocation} to {dropOffLocation}.");
            trip = new Trip(tripNumber, this, rideType, rideType.calculateFare(distance));
            NotificationService.sendNotification("Ride requested sent successfully", this, notificationMethod);

            if (trip.callTrip(admin, this, pickupLocation, dropOffLocation) == true)
            {
                {
                    trip.callRate();
                }
            }

        }


      
        // Change payment method before the end of the ride
        public void changePaymentMethod(IPaymentMethod newPaymentMethod)
        {
            this.preferredPaymentMethod = newPaymentMethod;
            Console.WriteLine($"{name} has changed the payment method to {newPaymentMethod.GetType().Name}.");
        }

        public void makePayment(Trip trip, double rate)
        {
            Console.WriteLine($"{name} is making payment of {trip.fare:C} for Trip {trip.id}.");
            preferredPaymentMethod.processPayment(trip.fare);
            rateDriver(trip.driver, rating);
        }


       public void rateDriver(Driver driver, double rating)
        {
            
            Console.WriteLine($"{name} rated driver {driver.name} with {rating} stars.");
            driver.updateRating(rating);
        }

        public void updateRating(double newRating)
        {
            rating = ((rating * totalTrips) + newRating) / (totalTrips + 1);
            totalTrips++;
            Console.WriteLine($"{name}'s new rating is {rating:F1} stars.");
        }
    }
}
