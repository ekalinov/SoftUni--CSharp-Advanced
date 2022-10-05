using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> tiresList = new List<Tire[]>();
            List<Engine> enginesList  = new List<Engine>();
            List<Car> carsList = new List<Car>();   
            List<Car> specialCars = new List<Car>();

            // collecting tires in List<Tire[]>
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "No more tires")
                {
                    break;
                }

                double[] inputTires = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

                var tires = new Tire[4];

                int counter = 0;

                for (int i = 0; i <= inputTires.Length - 2; i += 2)
                {
                    int tireYear = int.Parse(inputTires[i].ToString());
                    double tirePress = inputTires[i + 1];

                    tires[counter] = new Tire(tireYear,tirePress);
                    counter++;
                }

                tiresList.Add(tires);

            }


            // collecting Engines in List<Engine>
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Engines done")
                {
                    break;
                }

                double[] enigneArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

                int horsePwrs = int.Parse(enigneArgs[0].ToString());
                double engineCapacity = enigneArgs[1];

                var engine = new Engine(horsePwrs, engineCapacity);

                enginesList.Add(engine);
            }

            // collecting cars in List<car>
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Show special")
                {
                    break;
                }

                string[] carArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                //Audi A5 2017 200 12 0 0

                string carMake = carArgs[0];
                string carModel = carArgs[1];
                int carYear = int.Parse(carArgs[2]);
                double fuelQty = double.Parse(carArgs[3]);
                double fuelComsumption = double.Parse(carArgs[4]);
                int engineIndex = int.Parse(carArgs[5]);
                int tiresIndex = int.Parse(carArgs[6]);



                var car = new Car(carMake, carModel, carYear, fuelQty, fuelComsumption, enginesList[engineIndex], tiresList[tiresIndex]);

                carsList.Add(car);
            }

            // collecting Special CArs in List<car>
            foreach (var car in carsList)
            {
                double sumTirePress = 0D;
                foreach (var tire in car.Tires)
                {
                    sumTirePress += tire.Pressure;
                }
                
                if (car.Year>=2017 && car.Engine.HorsePower>300 && sumTirePress> 9 && sumTirePress<10)
                {
                    specialCars.Add(car);

                }

            }


            foreach (var car in specialCars)
            {
                car.Drive(20);

                Console.WriteLine($"Make: {car.Make}");
                Console.WriteLine($"Model: {car.Model}");
                Console.WriteLine($"Year: {car.Year}");
                Console.WriteLine($"HorsePowers: {car.Engine.HorsePower}");
                Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");
                // Make: Audi
                //Model: A5
                //Year: 2017
                //HorsePowers: 331
                //FuelQuantity: 197.6

            }



        }
    }
}
