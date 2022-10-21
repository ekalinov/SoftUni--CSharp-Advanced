using System;
using System.Collections.Generic;
using System.Linq;

namespace _0111111.BakeryShop
{
    internal class Program
    {

        class Product
        {

            public Product(string name, double ratio)
            {
                Name = name;
                Ratio = ratio;
                Times = 0;
            }

            public string Name { get; set; }
            public double Ratio { get; set; }

            public int Times { get; set; }


        }
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>()
            {
            new Product("Croissant", 50),
            new Product("Muffin", 40),
            new Product("Baguette",30),
            new Product("Bagel", 20)
            };


            Queue<double> water = new Queue<double>(Console.ReadLine()
                                          .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                          .Select(double.Parse)
                                          .ToArray());

            Stack<double> flour = new Stack<double>(Console.ReadLine()
                                          .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                          .Select(double.Parse)
                                          .ToArray());



            while (water.Any() && flour.Any())
            {

                double waterQty = water.Dequeue();
                double flourQty = flour.Pop();

                double currRatio = waterQty * 100 / (waterQty + flourQty);

                if (products.Any(x => x.Ratio == currRatio))
                {
                    var product = products.First(x => x.Ratio == currRatio);

                    product.Times++;
                }
                else
                {
                    double leftFlour = flourQty - waterQty;
                    flour.Push(leftFlour);
                    Product product = products.First(x => x.Name == "Croissant");
                    product.Times++;
                }

            }


            foreach (var product in products.Where(x => x.Times != 0).OrderByDescending(x => x.Times).ThenBy(x => x.Name))
            {
                Console.WriteLine($"{product.Name}: {product.Times}");
            }

            string waterLeft = water.Any() ? string.Join(", ", water) : "None";
            string flLeft = flour.Any() ? string.Join(", ", flour) : "None";

            Console.WriteLine($"Water left: {waterLeft}");
            Console.WriteLine($"Flour left: {flLeft}");





        }
    }
}
