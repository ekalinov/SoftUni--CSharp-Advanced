using System;
using System.Collections.Generic;
using System.Linq;

namespace _0111.Masterchef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> ingridients = new Queue<int>(Console.ReadLine()
                                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                            .Select(int.Parse)
                                            .ToArray());

            Stack<int> freshnesLevel = new Stack<int>(Console.ReadLine()
                                          .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                          .Select(int.Parse)
                                          .ToArray());


            Dictionary<string, int> dishes = new Dictionary<string, int>();


            while (ingridients.Any() && freshnesLevel.Any())
            {
                int ingridient = ingridients.Peek();
                int freshnes = freshnesLevel.Peek();


                if (ingridient == 0)
                {
                    ingridient = ingridients.Dequeue();
                    continue;
                }


                int dish = ingridient * freshnes;

                switch (dish)
                {
                    //Dipping sauce  150
                    //Green salad 250
                    //Chocolate cake  300
                    //Lobster 400

                    case 150:
                        if (!dishes.ContainsKey("Dipping sauce"))
                        {
                            dishes.Add("Dipping sauce", 0);
                        }
                        dishes["Dipping sauce"]++;
                        break;

                    case 250:
                        if (!dishes.ContainsKey("Green salad"))
                        {
                            dishes.Add("Green salad", 0);
                        }
                        dishes["Green salad"]++;
                        break;

                    case 300:
                        if (!dishes.ContainsKey("Chocolate cake"))
                        {
                            dishes.Add("Chocolate cake", 0);
                        }
                        dishes["Chocolate cake"]++;
                        break;

                    case 400:
                        if (!dishes.ContainsKey("Lobster"))
                        {
                            dishes.Add("Lobster", 0);
                        }
                        dishes["Lobster"]++;
                        break;

                    default:
                        ingridient += 5;
                        ingridients.Enqueue(ingridient);

                        break;

                }

                ingridient = ingridients.Dequeue();
                freshnes = freshnesLevel.Pop();
            }

            if (dishes.Count() >= 4)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if (ingridients.Any())
            {
                Console.WriteLine($"Ingredients left: {ingridients.Sum()}");
            }

            foreach (var dish in dishes.OrderByDescending(x => x.Value).ThenBy(n => n.Key))
            {
                Console.WriteLine($" # {dish.Key} --> {dish.Value}");
            }



        }
    }
}
