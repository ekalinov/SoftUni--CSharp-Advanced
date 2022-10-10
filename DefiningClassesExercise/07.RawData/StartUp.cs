using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.RawData
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();


            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Car car = new Car(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));

                cars.Add(car);
            }

            string cargoType = Console.ReadLine();
            if (cargoType== "fragile")
            {
                List<Car> fragileCars = cars.Where(car => car.Cargo.Type == "fragile" && car.Tires.Any(c => c.Pressure < 1)).ToList();
                                                

                foreach (var car in fragileCars)
                {
                    Console.WriteLine(car.Model);
                }
                
            }
            else
            {
                List<Car> flammableCars = cars.Where(car => car.Cargo.Type == "flammable"
                                          && car.Engine.Power>250).ToList();

                foreach (var car in flammableCars)
                {
                    Console.WriteLine(car.Model);
                }
            }


        }
    }
}
