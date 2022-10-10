using System;
using System.Collections.Generic;

namespace _06.SpeedRacing
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Dictionary<string,Car> cars = new Dictionary<string, Car>();


            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] carProps = Console.ReadLine().Split(" ");

                string carName = carProps[0];
                double fuel = double.Parse(carProps[1]);
                double fuelConsup = double.Parse(carProps[2]);

                Car car = new Car(carName, fuel, fuelConsup);


                cars.Add(carName,car);
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input=="End")
                {
                    break;
                }

                string[] driveArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string carName = driveArgs[1];
                double distToTravel = double.Parse(driveArgs[2]);

                Car car = cars[carName];

               car.Drive(car,distToTravel);



            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Key} {car.Value.FuelAmount:F2} {car.Value.TravelledDistance}");
            }


        }
    }
}
