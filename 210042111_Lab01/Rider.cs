using System;

namespace _210042111_Lab01
{
    public class Rider : User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string location { get; set; }
        public double rating { get; set; }
        public int totalTrips { get; set; }
        public PaymentMethod preferredPaymentMethod { get; set; }
        public NotificationType notificationMethod { get; set; }

        public Rider(int id, string name, NotificationType notificationMethod)
        {
            this.id = id;
            this.name = name;
            rating = 0.0; 
            totalTrips = 0;
            this.notificationMethod = notificationMethod;
        }

        public Trip RequestRide(string pickupLocation, string dropOffLocation, RideType rideType, double distance, int tripNumber)
        {
            Console.WriteLine($"{name} is requesting a {rideType.name} ride from {pickupLocation} to {dropOffLocation}.");
            Trip trip = new Trip(tripNumber, this, pickupLocation, dropOffLocation, rideType, rideType.calculateFare(distance));
            NotificationService.sendNotification("Ride requested sent successfully", this, notificationMethod);
            return trip;
        }

        public void makePayment(Trip trip, double rating)
        {
            Console.WriteLine($"{name} is making payment for trip {trip.id} using {preferredPaymentMethod.GetType().Name}.");
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
