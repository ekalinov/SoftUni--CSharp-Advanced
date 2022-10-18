using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.GenericSwapMethodIntegers
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
         
            Box<int> newBox = new Box<int>();

            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());


                newBox.list.Add(input);
            }

            int[] indices = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                              .Select(int.Parse)
                                              .ToArray();

            newBox.SwapMethod(indices[0], indices[1]);


            Console.WriteLine(newBox.ToString());
        }
    }
}
