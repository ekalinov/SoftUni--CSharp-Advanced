using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Froggy
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<int> items = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();


            Lake stones = new Lake(items);

            stones.Jumping();

        }
    }
}
