using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Same_Values_in_Array
{
    internal class Program
    {
        private static object dictionary;

        static void Main(string[] args)
        {

            double[] inputNums = Console.ReadLine()
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .Select(double.Parse)
                                .ToArray();

            Dictionary<double,int> numsOcc = new Dictionary<double,int>();

            foreach (double item in inputNums)
            {
                if (!numsOcc.ContainsKey(item))
                {
                    numsOcc.Add(item, 0);
                }

                numsOcc[item]++;
            }

            foreach (KeyValuePair<double,int> item in numsOcc)
            {

                Console.WriteLine($"{item.Key} - {item.Value} times");
            }




        }
    }
}
