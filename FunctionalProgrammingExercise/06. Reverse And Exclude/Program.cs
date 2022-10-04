using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToList();

            int dividerNum = int.Parse(Console.ReadLine());


            Action<List<int>> reverse = numbers => numbers.Reverse();
            Predicate<int> divider = number => number % dividerNum != 0;
         


            reverse(numbers);

            var result = numbers.FindAll(divider);

            Console.WriteLine(string.Join(" ",result));



        }
    }
}
