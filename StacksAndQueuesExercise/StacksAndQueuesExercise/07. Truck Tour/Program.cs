using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    internal class Program
    {

        public class PetrolStation
        {
            public PetrolStation(int liters, int kilometersToNext, int index)
            {
                this.Index = index;
                this.Liters = liters;
                this.KilometersToNext = kilometersToNext;
            }
            public int Index { get; private set; }
            public int Liters { get; set; }
            public int KilometersToNext { get; set; }
        }



        static void Main(string[] args)
        {
            int StationsCount = int.Parse(Console.ReadLine());

            Queue<PetrolStation> stations = new Queue<PetrolStation>();

            int litersInTruck = 0;

            for (int i = 0; i < StationsCount; i++)
            {
                int[] stationsInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();

                int currStationLiters = stationsInfo[0];
                int currKilometers = stationsInfo[1];
                int currIndex = i;

                stations.Enqueue(new PetrolStation(currStationLiters, currKilometers, currIndex));
            }



            bool isCircleCompleted = true;



            for (int i = 0; i < stations.Count; i++)
            {
                if (i != 0) stations.Enqueue(stations.Dequeue());

                for (int j = 0; j < stations.Count; j++)
                {
                    PetrolStation currStation = stations.Dequeue();

                    litersInTruck += currStation.Liters - currStation.KilometersToNext;


                    if (litersInTruck < 0)
                    {
                        isCircleCompleted = false;

                        //stations.Enqueue(currStation);
                        //break;

                    }

                    stations.Enqueue(currStation);

                }

                if (isCircleCompleted)
                {
                    Console.WriteLine(i);
                    break;

                }
                litersInTruck = 0; // Moved here
                isCircleCompleted = true;
            }

        }


    }
}
