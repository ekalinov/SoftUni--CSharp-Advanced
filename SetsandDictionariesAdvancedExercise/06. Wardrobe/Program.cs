using System;
using System.Collections.Generic;

namespace _06._Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> wardrobe =
                                                     new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] inputArgs = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string colour = inputArgs[0];

                if (!wardrobe.ContainsKey(colour))
                {
                    wardrobe.Add(colour, new Dictionary<string, int>());
                }

                string[] clothes = inputArgs[1].Split(",", StringSplitOptions.RemoveEmptyEntries);


                foreach (var item in clothes)
                {
                    if (!wardrobe[colour].ContainsKey(item))
                    {
                        wardrobe[colour].Add(item, 0);
                    }
                    wardrobe[colour][item]++;
                }

            }

            string[] searchedClothes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string searchedColor = searchedClothes[0];
            string searchedType=searchedClothes[1];

            foreach (var colour in wardrobe)
            {
                Console.WriteLine($"{colour.Key} clothes: ");

                foreach (var item in colour.Value)
                {
                    if (item.Key==searchedType && colour.Key==searchedColor)
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value}");

                    }
                }

            }
        }
    }
}
