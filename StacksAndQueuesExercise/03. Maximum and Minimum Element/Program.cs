using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                string[] inputArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = inputArgs[0];


                switch (command)
                {
                    case "1":
                        int numToPush = int.Parse(inputArgs[1]);
                        stack.Push(numToPush);
                        break;

                    case "2":
                        if (stack.Count > 0)
                            stack.Pop();

                        break;

                    case "3":
                        if (stack.Count > 0)
                            Console.WriteLine(stack.Max());
                        else
                            continue;
                        break;

                    case "4":
                        if (stack.Count > 0)
                            Console.WriteLine(stack.Min());
                        else
                            continue;
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", stack));



        }
    }
}
