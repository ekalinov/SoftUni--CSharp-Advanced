using System;
using System.Collections.Generic;

namespace _07._Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string > cars = new HashSet<string>();

            while (true)
            {
                string[] strings = Console.ReadLine().Split(", ");

                string cmd = strings[0];

                if (cmd=="END")
                {
                    break;
                }

                string car = strings[1];


                if (cmd == "IN")
                {
                    cars.Add(car);
                }
                else
                {
                    cars.Remove(car);
                }

            }

            if (cars.Count>0)
            {
                foreach (var car in cars)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }






        }
    }
}
