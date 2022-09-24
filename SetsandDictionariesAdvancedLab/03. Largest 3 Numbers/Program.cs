using System;
using System.Linq;

namespace _03._Largest_3_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputNums = Console.ReadLine()
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .OrderByDescending(x=>x)
                                .Take(3)
                                .ToArray();
                    


            Console.WriteLine(string.Join(' ',inputNums));

        }
    }
}
