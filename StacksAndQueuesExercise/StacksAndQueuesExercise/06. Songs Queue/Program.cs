using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] orders = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            Queue<string> songsQue = new Queue<string>(orders);

            while (songsQue.Count != 0)
            {
                string input = Console.ReadLine();
                string[] inputArgs = input.Split(" ");
                string cmd = inputArgs[0];

                switch (cmd)
                {
                    case "Play":
                        songsQue.Dequeue();
                        break;
                    case "Add":
                        //•	"Add {song}" - adds the song to the queue if it isn’t contained already,
                        //otherwise print "{song} is already contained!"

                        string song = input.Remove(0,4);

                        if (songsQue.Contains(song))
                        {
                            Console.WriteLine($"{song} is already contained!");
                            continue;
                        }
                        songsQue.Enqueue(song);

                        break;
                    case "Show":
                        //•	"Show" - prints all songs in the queue separated by a comma and a white space
                        //(start from the first song in the queue to the last)

                        Console.WriteLine(string.Join(", ",songsQue));
                        break;
                }


            }







        }
    }
}
