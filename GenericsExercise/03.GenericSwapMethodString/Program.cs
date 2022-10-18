using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.GenericSwapMethodString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<string>> stringsList = new List<Box<string>>();
                Box<string> newBox = new Box<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();


                newBox.list.Add(input);
            }

            int[] indices = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                              .Select(int.Parse)
                                              .ToArray();

            newBox.SwapMethod(indices[0], indices[1]);


            Console.WriteLine(  newBox.ToString()); 
        }
    }
}
