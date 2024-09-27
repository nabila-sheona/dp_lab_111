using System;

namespace _210042111_Lab01
{
    public class Driver : User
    {
   
        public string vehicleType { get; set; }
     
        public bool isAvailable { get; set; }
        public NotificationType notificationMethod { get; set; }

        public Admin admin { get; set; }
        public Driver(int id, string name, string vehicleType, NotificationType notificationMethod, string location)
        {
            this.id = id;
            this.name = name;
            this.vehicleType = vehicleType;
            rating = 0.0; 
            totalTrips = 0;
            isAvailable = true; 
            this.notificationMethod = notificationMethod;
            this.location = location;
        }

        public void acceptRide(Trip trip, Admin admin)
        {
            isAvailable = false;
            Console.WriteLine($"Driver {name} has accepted trip {trip.id}.");

           
        }



        public void completeRide()
        {  
            isAvailable = true;
            totalTrips++;
            Console.WriteLine($"Driver {name} just completed the trip.");

        }

        public void startTrip(Trip trip)
        {
            
            Console.WriteLine($"Driver {name} has started the trip.");
            trip.startTrip();
        }

        public void updateLocation(Admin admin, string newLocation)
        {
            this.admin = admin;
            location = newLocation;
            admin.updateDriverLocation(id, newLocation);
        }

        public void rateRider(Rider rider, double rating)
        {
            Console.WriteLine($"Driver {name} rated rider {rider.name} with {rating} stars.");
            totalTrips++;
            rider.updateRating(rating);
        }

        public void updateRating(double newRating)
        {
            rating = ((rating * totalTrips) + newRating) / (totalTrips + 1);
            Console.WriteLine($"Driver {name}'s new rating is {rating:F1} stars.");
        }
    }
}
