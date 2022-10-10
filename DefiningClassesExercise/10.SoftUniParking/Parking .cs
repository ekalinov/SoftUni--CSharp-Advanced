using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private Dictionary<string,Car> cars;

        private int capacity;


        public Parking(int capacity)
        {
            this.capacity = capacity;
            cars = new Dictionary<string, Car>();
        }

        public int Count
        {
            get { return cars.Count; }
        }


        public  string AddCar(Car car)
        {
            if (cars.ContainsKey(car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
               
            }

            if (cars.Count==capacity)
            {
                return "Parking is full!";
              
            }

            cars.Add(car.RegistrationNumber,car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";

        }

        public string RemoveCar(string registrationNumber) 
        {

            if (cars.ContainsKey(registrationNumber))
            {
                cars.Remove(registrationNumber);
                return $"Successfully removed {registrationNumber}";
               
            }

            return "Car with that registration number, doesn't exist!";

        }

        public Car GetCar(string registrationNumber)
        {
            return cars.FirstOrDefault(c => c.Key == registrationNumber).Value;
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {

            for (int i = 0; i < registrationNumbers.Count; i++)
            {
                RemoveCar(registrationNumbers[i]);
            }
        }


    }
}
