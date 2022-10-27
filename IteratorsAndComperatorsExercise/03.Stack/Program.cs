using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();


            string cmdArgs;
            while ((cmdArgs= Console.ReadLine()) != "END")
            {
                    string cmd = cmdArgs.Substring(0,3);

                switch (cmd)
                {
                    case "Pop":
                        try
                        {
                            var element = stack.Pop();
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine( ex.Message);
                        }
                        break;

                    default:
                        
                        List<string> items = cmdArgs.Split(new[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries)
                                                    .Skip(1)
                                                    .ToList();

                        stack.Push(items);

                        break;
                }
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }


        }
    }
}
