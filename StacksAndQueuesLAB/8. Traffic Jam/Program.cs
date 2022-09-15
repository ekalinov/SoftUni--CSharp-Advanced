using System;
using System.Collections.Generic;

namespace _8._Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();

            int totalCarsPassed = 0;

            while (true)
            {
                string cmd = Console.ReadLine();
                if (cmd == "end")
                    break;

                if (cmd == "green")
                {

                    for (int i = 0; i < n; i++)
                    {
                        if (cars.Count > 0)
                        {

                            var currCar = cars.Dequeue();

                            Console.WriteLine($"{currCar} passed!");

                            totalCarsPassed++;
                            
                        }

                    }
                    continue;
                }

                cars.Enqueue(cmd);

            }

            Console.WriteLine($"{totalCarsPassed} cars passed the crossroads.");



        }
    }
}
