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

        public abstract double calculateFare(double distance);
    }

    public class Carpool : RideType
    {
        public Carpool()
        {
            this.name = "Carpool";
            this.baseFare = 20;
        }

        public override double calculateFare(double distance)
        {
            double perMileRate = 5; 
            return baseFare + (distance * perMileRate);
        }
    }

    public class LuxuryRide : RideType
    {
        public LuxuryRide()
        {
            this.name = "Luxury Ride";
            this.baseFare = 50;
        }

        public override double calculateFare(double distance)
        {
            double perMileRate = 15; 
            return baseFare + (distance * perMileRate);
        }
    }

    public class BikeRide : RideType
    {
        public BikeRide()
        {
            this.name = "Bike Ride";
            this.baseFare = 10;
        }

        public override double calculateFare(double distance)
        {
            double perMileRate = 2; 
            return baseFare + (distance * perMileRate);
        }
        //fare amount assumed in bdt

    }
}
