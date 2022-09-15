using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] clothes = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int rackCapacity = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>(clothes.Select(int.Parse));

            int racks = 1;
                int currCapacity = rackCapacity;



            while (stack.Count != 0)
            {
                int currClothes = stack.Pop();

                if (currCapacity < currClothes)
                {
                    racks++;
                    currCapacity = rackCapacity- currClothes;
                    continue;
                }
                currCapacity -= currClothes;
            }

            Console.WriteLine(racks);

        }
    }
}
    