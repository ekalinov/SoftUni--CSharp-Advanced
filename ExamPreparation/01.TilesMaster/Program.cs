using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.TilesMaster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> whiteTiles = new Stack<int>(Console.ReadLine()
                                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                            .Select(int.Parse)
                                            .ToArray());

            Queue<int> greyTiles = new Queue<int>(Console.ReadLine()
                                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                            .Select(int.Parse)
                                            .ToArray());

            Dictionary<string, int> locations = new Dictionary<string, int>();


            while (greyTiles.Any() && whiteTiles.Any())
            {
                int white = whiteTiles.Pop();
                int grey = greyTiles.Dequeue();

                if (white != grey)
                {
                    white /= 2;
                    whiteTiles.Push(white);
                    greyTiles.Enqueue(grey);
                    continue;
                }

                int newTile = white + grey;

                switch (newTile)
                {
                    case 40:
                        if (!locations.ContainsKey("Sink"))
                        {
                            locations.Add("Sink", 0);
                        }
                        locations["Sink"]++;
                        break;
                    case 50:
                        if (!locations.ContainsKey("Oven"))
                        {
                            locations.Add("Oven", 0);
                        }
                        locations["Oven"]++;
                        break;
                    case 60:
                        if (!locations.ContainsKey("Countertop"))
                        {
                            locations.Add("Countertop", 0);
                        }
                        locations["Countertop"]++;
                        break;
                    case 70:
                        if (!locations.ContainsKey("Wall"))
                        {
                            locations.Add("Wall", 0);
                        }
                        locations["Wall"]++;
                        break;
                    default:
                        if (!locations.ContainsKey("Floor"))
                        {
                            locations.Add("Floor", 0);
                        }
                        locations["Floor"]++;
                        break;
                }

            }


            if (whiteTiles.Any())
            {
                Console.WriteLine($"White tiles left: {string.Join(", ",whiteTiles)}");
            }
            else
            {
                Console.WriteLine($"White tiles left: none");
            }
            if (greyTiles.Any())
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", greyTiles)}");
            }
            else
            {
                Console.WriteLine($"Grey tiles left: none");
            }


            foreach (var kvp in locations.OrderByDescending(v=>v.Value).ThenBy(k=>k.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }



            //int white = whiteTiles.Dequeue();
            //int gray = greyTiles.Pop();

        }
    }
}
