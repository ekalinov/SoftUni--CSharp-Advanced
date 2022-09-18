using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Balanced_Parenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string inputParanthesis = Console.ReadLine();

            Stack<char> stack = new Stack<char>();


            if (inputParanthesis.Length % 2 == 0)
            {
                foreach (char item in inputParanthesis)
                {
                    if (item == '(' || item == '{' || item == '[')
                        stack.Push(item);

                    else
                    {
                        if (stack.Any())
                        {
                            char lastOpen = stack.Peek();

                            if ((lastOpen == '(' && item == ')')
                                || (lastOpen == '{' && item == '}')
                                    || (lastOpen == '[' && item == ']'))
                            {
                                stack.Pop();
                            }
                            else break;

                        }
                        else break;
                    }
                }

            Console.WriteLine(stack.Any() ? "NO" : "YES");
            }
            else
            {
                Console.WriteLine("NO");
            }





        }
    }
}
