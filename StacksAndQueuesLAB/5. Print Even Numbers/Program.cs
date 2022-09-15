using System;
using System.Collections.Generic;

namespace _5._Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Queue<string>   queue = new Queue<string>();

            foreach (var item in input)
            {
                if (int.Parse(item)%2==0)
                {
                    queue.Enqueue(item);
                }
            }

            Console.WriteLine(string.Join(", ",queue));

        }
    }
}
