using System;
using System.Collections.Generic;

namespace _08.CarSelesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            Dictionary<string, Engine> engines = new Dictionary<string, Engine>();
            List<Car> cars = new List<Car>();


            // ADD Engines in the dictionary

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] engineArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                //•	Model: a string property
                //•	Power: an int property
                //•	Displacement: an int property, it is optional
                //•	Efficiency: a string property, it is optional

                if (engineArgs.Length == 4)
                {
                    string model = engineArgs[0];
                    int powet = int.Parse(engineArgs[1]);
                    int displacement = int.Parse(engineArgs[2]);

                    string efficiency = engineArgs[3];

                    engines.Add(model, new Engine(model, powet, displacement, efficiency));
                }
                else if (engineArgs.Length == 3)
                {
                    string model = engineArgs[0];
                    int power = int.Parse(engineArgs[1]);
                    int displacement;
                    string efficiency = string.Empty;


                    if (int.TryParse(engineArgs[2], out displacement))
                    {
                        engines.Add(model, new Engine(model, power, displacement));
                        continue;
                    }

                    efficiency = engineArgs[2];


                    engines.Add(model, new Engine(model, power, efficiency));
                }
                else if (engineArgs.Length == 2)
                {
                    string model = engineArgs[0];
                    int power = int.Parse(engineArgs[1]);

                    engines.Add(model, new Engine(model, power));
                }
            }


            // ADD Cars in the list
            int m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                string[] carArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                //•	Model: a string property
                //•	Engine: a property holding the engine object
                //•	Weight: an int property, it is optional
                //•	Color: a string property, it is optional



                if (carArgs.Length == 4)
                {
                    string model = carArgs[0];
                    Engine engine = engines[carArgs[1]];
                    int weight = int.Parse(carArgs[2]);
                    string color = carArgs[3];

                    cars.Add(new Car(model, engine, weight, color));
                }
                else if (carArgs.Length == 3)
                {
                    string model = carArgs[0];
                    Engine engine = engines[carArgs[1]];
                    string color = string.Empty;

                    int weight;
                    if (int.TryParse(carArgs[2], out weight))
                    {
                        cars.Add(new Car(model, engine, weight));
                        continue;
                    }

                    color = carArgs[2];
                    cars.Add(new Car(model, engine, color));

                }
                else if (carArgs.Length == 2)
                {
                    string model = carArgs[0];
                    Engine engine = engines[carArgs[1]];

                    cars.Add(new Car(model, engine));
                }
            }


            foreach (var car in cars)
            {
                Console.WriteLine(Car.PrintCar(car));
            }




        }
    }
}
