using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputArgs = Console.ReadLine().Split(" ");
            string[] ints = Console.ReadLine().Split(" ");

            Stack<string> stack = new Stack<string>();


            int elementsToPush = int.Parse(inputArgs[0]);
            int elementsToPop = int.Parse(inputArgs[1]);
            int elementsToSearch = int.Parse(inputArgs[2]);


            for (int i = 0; i < elementsToPush; i++)
                stack.Push(ints[i]);


            for (int i = 0; i < elementsToPop; i++)
            {
                if (stack.Count > 0)
                {
                    stack.Pop();
                }
            }

            if (stack.Contains(elementsToSearch.ToString()))
                Console.WriteLine("true");

            else if (stack.Count == 0)
                Console.WriteLine("0");
            else
            {
                int[] itemsLeft = stack.Select(int.Parse).ToArray();

                Console.WriteLine(itemsLeft.Min());
            }

        }
    }
}
