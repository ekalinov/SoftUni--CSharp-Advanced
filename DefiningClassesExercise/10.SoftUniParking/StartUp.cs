using System;
using System.Collections.Generic;

namespace SoftUniParking
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            var car = new Car("Skoda", "Fabia", 65, "CC1856BG");
            var car3 = new Car("Skoda", "Fabia", 65, "CC18526BG");
            var car4 = new Car("Skoda", "Fabia", 65, "CC18562BG");
            var car5 = new Car("Skoda", "Fabia", 65, "CC12856BG");
            var car6= new Car("Skoda", "Fabia", 65,  "CCr1856BG");
            var car2 = new Car("Audi", "A3", 110, "EB8787MN");

            Console.WriteLine(car.ToString());
            // Make: Skoda
            // Model: Fabia
            // HorsePower: 65
            // RegistrationNumber: CC1856BG

            var parking = new Parking(10);
            Console.WriteLine(parking.AddCar(car));
            Console.WriteLine(parking.AddCar(car3));
            Console.WriteLine(parking.AddCar(car4));
            Console.WriteLine(parking.AddCar(car5));
            Console.WriteLine(parking.AddCar(car6));
            // Successfully added new car Skoda CC1856BG

            Console.WriteLine(parking.AddCar(car));
            // Car with that registration number, already exists!

            Console.WriteLine(parking.AddCar(car2));
            // Successfully added new car Audi EB8787MN

            Console.WriteLine(parking.GetCar("EB8787MN").ToString());
            // Make: Audi
            // Model: A3
            // HorsePower: 110
            // RegistrationNumber: EB8787MN
            List<string> nums = new List<string>()
            {
            "CC18526BG",
            "CC18562BG",
            "CC12856BG",
            "CCr1856BG",

            };



            Console.WriteLine(parking.RemoveCar("EB8787MN"));
            // Successfullyremoved EB8787MN
           parking.RemoveSetOfRegistrationNumber(nums);
            Console.WriteLine(parking.Count);
            // 1

        }
    }
}
