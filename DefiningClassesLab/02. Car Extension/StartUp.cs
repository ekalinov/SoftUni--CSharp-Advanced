using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {


            Car car = new Car();

            car.Make = "BMW";
            car.Model = "X35";
            car.Year = 2222;
            car.FuelConsumption = 0.08;
            car.FuelQuantity = 100;

            car.Drive(50);

            Console.WriteLine(car.WhoAmI());

            while (true)
            {
                car.Drive(double.Parse(Console.ReadLine()));
                Console.WriteLine(car.FuelQuantity);
            }

        }
    }
}
