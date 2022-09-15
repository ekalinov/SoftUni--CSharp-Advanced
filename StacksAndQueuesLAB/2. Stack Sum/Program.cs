using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] ints = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Stack<int> stack = new Stack<int>();

            foreach (var item in ints)
            {
                stack.Push(int.Parse(item));
            }


            while (true)
            {
                string[] cmd = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);


                if (cmd[0].ToLower() == "add")
                {
                    int firstNum = int.Parse(cmd[1]);
                    int secondNum = int.Parse(cmd[2]);

                    stack.Push(firstNum);
                    stack.Push(secondNum);
                }
                else if (cmd[0].ToLower() == "remove")
                {
                    int n = int.Parse(cmd[1]);
                    if (stack.Count >= n)
                    {
                        for (int i = 0; i < n; i++)
                            stack.Pop();
                    }
                }
                else
                    break;
            }
            Console.WriteLine($"Sum: {stack.Sum()}");
        }

    }
}

