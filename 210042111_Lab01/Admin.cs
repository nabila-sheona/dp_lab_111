using System;
using System.Collections.Generic;
using System.Linq;

namespace _210042111_Lab01
{
    public class Admin
    {
        public int id { get; set; }
        public string name { get; set; }
        public string role { get; set; }

        private List<Driver> drivers;
        private List<Rider> riders;
        private List<Trip> trips;

        public Admin(int id, string name, string role)
        {
            this.id = id;
            this.name = name;
            this.role = role;
            drivers = new List<Driver>();
            riders = new List<Rider>();
            trips = new List<Trip>();
        }

        public void seeRiders()
        {
            Console.WriteLine("Riders:");
            foreach (var rider in riders)
            {
                Console.WriteLine(rider.name);
            }
        }

        public void seeDrivers()
        {
            Console.WriteLine("Drivers:");
            foreach (var driver in drivers)
            {
                Console.WriteLine(driver.name);
            }
        }

        public void manageRider(Rider rider, bool status)
        {
            if (status)
            {
                if (!riders.Contains(rider))
                {
                    riders.Add(rider);
                    Console.WriteLine($"Driver {rider.name} is available now.");
                }
            }
            else
            {
                if (riders.Contains(rider))
                {
                    riders.Remove(rider);
                    Console.WriteLine($"Driver {rider.name} is not available now.");
                }
            }
        }

        public void manageDriver(Driver driver, bool status)
        {
            if (status)
            {
                if (!drivers.Contains(driver))
                {
                    drivers.Add(driver);
                    Console.WriteLine($"Driver {driver.name} is available now.");
                }
            }
            else
            {
                if (drivers.Contains(driver))
                {
                    drivers.Remove(driver);
                    Console.WriteLine($"Driver {driver.name} is not available now.");
                }
            }
        }

    
        public void tripHistory()
        {
            //trip will add to the system if only it is completed
            Console.WriteLine("Trip History:");
            foreach (var trip in trips.Where(t => t.isCompleted))
            {
                Console.WriteLine($"Trip id: {trip.id}, Pickup: {trip.pickupLocation}, Dropoff: {trip.dropOffLocation}, Payable amount: {trip.fare}, Complete status: {trip.isCompleted}");
            }
        }

        public bool assignTrip(Trip trip, string pickuplocation)
        {
            if (trip == null)
            {
                Console.WriteLine("Error: Trip is not specified. Cannot assign.");
                return false;
            }

            
            var availableDriver = drivers
                .Where(d => d.isAvailable && d.location == pickuplocation)
                .FirstOrDefault();

            if (availableDriver == null)
            {
                Console.WriteLine($"No driver is available at the pickup location {trip.pickupLocation} for trip {trip.id}. Trip will be added as not assigned.");
                
                trips.Add(trip);
                return false;
            }

      
            trip.assignDriver(availableDriver, this);
            trips.Add(trip);
            Console.WriteLine($"Trip {trip.id} has been assigned to driver {availableDriver.name}.");
            return true;
        }


        public void updateDriverLocation(int driverId, string newLocation)
        {
            var existingDriver = drivers.FirstOrDefault(d => d.id == driverId);
            if (existingDriver != null)
            {
                existingDriver.location = newLocation;
                Console.WriteLine($"Driver {existingDriver.name}'s location updated in the system to {newLocation}.");
            }
        }
    }
}
