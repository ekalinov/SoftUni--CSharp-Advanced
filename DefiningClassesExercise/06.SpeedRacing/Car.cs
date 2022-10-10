using System;
using System.Collections.Generic;
using System.Text;

namespace _06.SpeedRacing
{
    public class Car
    {
        Dictionary<string,Car> cars = new Dictionary<string, Car>();

        

        public  Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            TravelledDistance = 0;
        }


        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        public  void Drive(Car carName, double distToTravel)
        {
            double fuelNeededForTrip = distToTravel * this.FuelConsumptionPerKilometer;
            double fuelRemaining = this.FuelAmount - fuelNeededForTrip;

            if (fuelRemaining<0)
            {
                Console.WriteLine("Insufficient fuel for the drive");
                return;
            }
          
            this.FuelAmount = fuelRemaining;
           this. TravelledDistance +=distToTravel;


        }


    }
}
