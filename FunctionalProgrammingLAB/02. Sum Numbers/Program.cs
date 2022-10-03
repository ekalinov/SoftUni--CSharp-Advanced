using System;
using System.Linq;

namespace _02._Sum_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {    
                int[] inputArray=Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                Console.WriteLine(inputArray.Length);
                Console.WriteLine(inputArray.Sum());
        }
    }
}
