using System;
using System.Collections.Generic;

namespace _7._Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names= Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            int n = int.Parse(Console.ReadLine());

            Queue<string> players = new Queue<string>(names);

            while (players.Count>1)
            {

                for (int i = 1; i < n; i++)
                {
                  string player =  players.Dequeue();
                    players.Enqueue(player);
                }
                string lostPlayer = players.Dequeue();
                Console.WriteLine($"Removed {lostPlayer}");
                
            }
             string lastPlayer = players.Dequeue();
            Console.WriteLine($"Last is {lastPlayer}");

        }
    }
}
