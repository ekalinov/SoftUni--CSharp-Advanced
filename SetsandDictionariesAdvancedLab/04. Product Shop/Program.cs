using System;
using System.Collections.Generic;

namespace _04._Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string,Dictionary<string,double>> shops =
                new SortedDictionary<string, Dictionary<string, double>>();


            while (true)
            {
                string[] inputArgs = Console.ReadLine()
                                            .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string shopName = inputArgs[0];

                if (shopName== "Revision")
                {
                    Revision(shops);
                    break;
                }

                string product = inputArgs[1];
                double price = double.Parse(inputArgs[2]);

                if (!shops.ContainsKey(shopName))
                {
                    shops.Add(shopName, new Dictionary<string, double>());
                }

                if (!shops[shopName].ContainsKey(product))
                {
                    shops[shopName].Add(product,0d);
                }

                shops[shopName][product] = price;

            }

        }

        private static void Revision(SortedDictionary<string, Dictionary<string, double>> shops)
        {
            foreach (var shop in shops)
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }

            }

        }
    }
}
