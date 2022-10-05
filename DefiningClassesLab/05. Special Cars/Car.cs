using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        //Fields
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;

        private Engine engine;
        private Tire[] tires;



        //Constructors
        public Car()
        {
            Make = "VW";
            Model = "Golf";
            Year = 2025;
            FuelQuantity = 200;
            FuelConsumption = 10;
        }

        public Car(string make, string model, int year) : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;

        }

        public Car(string make, string model, int year, double fQuantity, double fConsumption) : this(make, model, year)
        {
            this.FuelQuantity = fQuantity;
            this.FuelConsumption = fConsumption;
        }

        public Car(string make, string model, int year, double fQuantity, double fConsumption, Engine engine, Tire[] tires) 
                                                    : this(make, model, year, fQuantity, fConsumption)
        {

            this.Engine = engine;
            this.Tires = tires;

        }



        //prop
        public string Make
        {
            get { return make; }
            set { make = value; }
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set { fuelQuantity = value; }
        }
        public double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }

        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }
        public Tire[] Tires
        {
            get { return tires; }
            set { tires = value; }
        }



        //Methods
        public void Drive(double distance)
        {
            double neededFuel = distance * fuelConsumption/100;
            if (fuelQuantity - neededFuel < 0)
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
                return;
            }

            fuelQuantity -= neededFuel;
        }

        public string WhoAmI()
        {
            string outputString = $"Make: {this.Make}\r\n" +
                $"Model: {this.Model}\r\n" +
                $"Year: {this.Year}\r\n" +
                $"Fuel: {this.FuelQuantity:F2}";

            return outputString;
        }

    }
}
