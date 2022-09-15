using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Queue_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] inputArgs = Console.ReadLine().Split(" ");
            string[] ints = Console.ReadLine().Split(" ");

            Queue<string> queue= new Queue<string>();


            int elementsToPush = int.Parse(inputArgs[0]);
            int elementsToPop = int.Parse(inputArgs[1]);
            int elementsToSearch = int.Parse(inputArgs[2]);


            for (int i = 0; i < elementsToPush; i++)
                queue.Enqueue(ints[i]);


            for (int i = 0; i < elementsToPop; i++)
            {
                if (queue.Count > 0)
                {
                    queue.Dequeue();
                }
            }

            if (queue.Contains(elementsToSearch.ToString()))
                Console.WriteLine("true");

            else if (queue.Count == 0)
                Console.WriteLine("0");
            else
            {
                int[] itemsLeft = queue.Select(int.Parse).ToArray();

                Console.WriteLine(itemsLeft.Min());
            }

        }
    }
}
