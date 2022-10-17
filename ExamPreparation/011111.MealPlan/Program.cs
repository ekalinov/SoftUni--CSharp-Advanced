using System;
using System.Collections.Generic;
using System.Linq;

namespace _011111.MealPlan
{
    internal class Program
    {
        class Meal
        {

            public Meal(string name, int calories)
            {
                Name = name;
                Calories = calories;
            }

            public string Name { get; set; }
            public int Calories { get; set; }


        }


        static void Main(string[] args)
        {

            List<Meal> mealsList = new List<Meal>()
            {
            new Meal("salad", 350),
            new Meal("soup", 490),
            new Meal("pasta", 680),
            new Meal("steak", 790),
            };


            Queue<string> mealsQueue = new Queue<string>(Console.ReadLine()
                                           .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                           .ToArray());

            Stack<int> dailyCalories = new Stack<int>(Console.ReadLine()
                                          .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                          .Select(int.Parse)
                                          .ToArray());



            int leftCalories = 0;
            int mealCounter = 0;

            while (mealsQueue.Any() && dailyCalories.Any())
            {
                leftCalories = 0;
                int dayCalories = dailyCalories.Pop();

                while (dayCalories > 0 && mealsQueue.Any())
                {

                    string name = mealsQueue.Dequeue();
                    Meal meal = mealsList.FirstOrDefault(x => x.Name == name);
                    mealCounter++;
                    dayCalories -= meal.Calories;

                    if (dayCalories < 0)
                    {
                        leftCalories = Math.Abs(dayCalories);
                        if (dailyCalories.Any())
                        {
                            dayCalories = dailyCalories.Pop() - leftCalories;
                            dailyCalories.Push(dayCalories);

                        }
                        break;
                    }
                    
                    if (!mealsQueue.Any())
                    {
                        dailyCalories.Push(dayCalories);

                    }
                }

            }

            if (mealsQueue.Count == 0)
            {
                Console.WriteLine($"John had {mealCounter} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", dailyCalories)} calories.");

            }
            else
            {
                Console.WriteLine($"John ate enough, he had {mealCounter} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", mealsQueue)}.");


            }





        }
    }
}