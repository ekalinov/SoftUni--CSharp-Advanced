using System;
using System.Collections.Generic;

namespace _3._Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            Stack<string> stack = new Stack<string>();
           Array.Reverse(input);

            foreach (var item in input)
            {
                stack.Push(item);
            }

            while (true)
            {
                if (stack.Count==1)
                {
                    break;
                }
              int FirstNum = int.Parse(stack.Pop());
                string action = stack.Pop();
                int SecondNum  = int.Parse(stack.Pop());

                if (action == "+")
                {
                    int sum = FirstNum + SecondNum;
                    stack.Push(sum.ToString());
                }
                else
                {
                    int sum = FirstNum - SecondNum;
                    stack.Push(sum.ToString());
                }

            }

            Console.WriteLine(stack.Pop());
        }
    }
}
