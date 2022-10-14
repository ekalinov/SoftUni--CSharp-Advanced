using System;
using System.Collections.Generic;
using System.Linq;

namespace _011.BirthayCelebration
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Queue<int> guests = new Queue<int>(Console.ReadLine()
                                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                            .Select(int.Parse)
                                            .ToArray());

            Stack<int> plates = new Stack<int>(Console.ReadLine()
                                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                            .Select(int.Parse)
                                            .ToArray());

            int wastedFood = 0;

            while (guests.Any() && plates.Any())
            {
                int currGuest = guests.Dequeue();
                int plate = plates.Pop();

                int difference = plate - currGuest;

                while (difference < 0)
                {
                    if (!plates.Any())
                    {
                        break;
                    }
                    currGuest -= plate;
                     plate = plates.Pop();
                    difference = plate - currGuest;
                }

                wastedFood += difference;
              
            }

            if (plates.Any())
            {
                Console.WriteLine($"Plates: {string.Join(" ", plates)}");

            }

            if (guests.Any())
            {

                Console.WriteLine($"Guests: {string.Join(" ", guests)}");

            }

            Console.WriteLine($"Wasted grams of food: {wastedFood}");



        }
    }
}
