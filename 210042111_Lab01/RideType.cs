using System;

namespace _210042111_Lab01
{
    public abstract class RideType
    {
        public string name { get; set; }
        public double baseFare { get; set; }

      
        public RideType()
        {
        }

        public abstract double calculateFare(double distance, DateTime tripTime);
    }

    public class Carpool : RideType
    {
        public Carpool()
        {
            this.name = "Carpool";
            this.baseFare = 2.0;
        }

        public override double calculateFare(double distance, DateTime tripTime)
        {
            double perMileRate = 0.5; 
            return baseFare + (distance * perMileRate);
        }
    }

    public class LuxuryRide : RideType
    {
        public LuxuryRide()
        {
            this.name = "Luxury Ride";
            this.baseFare = 5.0;
        }

        public override double calculateFare(double distance, DateTime tripTime)
        {
            double perMileRate = 1.5; 
            return baseFare + (distance * perMileRate);
        }
    }

    public class BikeRide : RideType
    {
        public BikeRide()
        {
            this.name = "Bike Ride";
            this.baseFare = 1.0;
        }

        public override double calculateFare(double distance, DateTime tripTime)
        {
            double perMileRate = 0.2; 
            return baseFare + (distance * perMileRate);
        }


    }
}
