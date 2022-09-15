using System;
using System.Collections.Generic;

namespace _6._Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {

        Queue<string> clients = new Queue<string>();    


            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                    break;
                if (input == "Paid")
                {
                    Console.WriteLine(string.Join(Environment.NewLine, clients));
                    clients.Clear();
                    continue;
                }

                clients.Enqueue(input);

            }

            Console.WriteLine($"{clients.Count} people remaining.");
        }
    }
}
