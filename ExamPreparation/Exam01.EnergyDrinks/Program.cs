using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int DAYLYDOSAGE = 300;

            Stack<int> caffeine = new Stack<int>(Console.ReadLine()
                                          .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                          .Select(int.Parse)
                                          .ToArray());

            Queue<int> energyDrinks = new Queue<int>(Console.ReadLine()
                                          .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                          .Select(int.Parse)
                                          .ToArray());



            int caffeineTaken = 0;

            while (caffeine.Any() && energyDrinks.Any())
            {

                int  currCaffeine = caffeine.Pop();
                int currEnergyDrink = energyDrinks.Dequeue();

                int dosage = currCaffeine * currEnergyDrink;

                if (caffeineTaken + dosage<=300)
                {
                    caffeineTaken+=dosage;
                }
                else
                {
                    caffeineTaken -= 30;
                    if (caffeineTaken<0)
                    {
                        caffeineTaken = 0;
                    }
                    energyDrinks.Enqueue(currEnergyDrink);
                }

            }

            if (energyDrinks.Any())
            {
                Console.WriteLine($"Drinks left: { string.Join(", ",energyDrinks)}");
            }
            else
            {
                Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
            }

            Console.WriteLine($"Stamat is going to sleep with {caffeineTaken} mg caffeine.");


        }
    }
}
