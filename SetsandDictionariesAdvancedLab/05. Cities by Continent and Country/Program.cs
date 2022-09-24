using System;
using System.Collections.Generic;

namespace _05._Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> continents =
                new Dictionary<string, Dictionary<string, List<string>>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {


                string[] inputArgs = Console.ReadLine()
                                            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string continent = inputArgs[0];
                string country = inputArgs[1];
                string city = inputArgs[2];

                if (!continents.ContainsKey(continent))
                {
                    continents.Add(continent, new Dictionary<string, List<string>>());
                }

                if (!continents[continent].ContainsKey(country))
                {
                    continents[continent].Add(country, new List<string>());
                }

                continents[continent][country].Add(city);

            }

            Print(continents);

        }

        private static void Print(Dictionary<string, Dictionary<string, List<string>>> continents)
        {
            foreach (var continent in continents)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach (var country in continent.Value)
                {
                    Console.Write($"{country.Key} -> ");
                    Console.WriteLine(String.Join(", ", country.Value));
                }

            }
        }


    }
}
