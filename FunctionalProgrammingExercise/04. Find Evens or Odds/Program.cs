using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                            .Select(int.Parse)
                                            .ToArray();

            string evenOrOdd = Console.ReadLine();


            List<int> numbers = new List<int>();

            for (int i = range[0]; i <= range[1]; i++)
            {
                numbers.Add(i);
            }

            Predicate<int> even = num => num % 2 == 0;
            Predicate<int> odd = num => num % 2 != 0;

            if (evenOrOdd =="even")
            {
                Console.WriteLine(String.Join(" ",numbers.FindAll(even)));
            }
            else
            {
                Console.WriteLine(String.Join(" ", numbers.FindAll(odd)));

            }

        }
    }
}
