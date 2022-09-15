using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int food = int.Parse(Console.ReadLine());
            string[] orders = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Queue<int> ordersQue = new Queue<int>(orders.Select(int.Parse));
            Console.WriteLine(ordersQue.Max());

            int foodAvailble = food;


            for (int i = 0; i < orders.Length; i++)
            {

                int currOrder = int.Parse(orders[i]);

                if (foodAvailble < currOrder)
                {
                    Console.Write("Orders left: ");
                    Console.WriteLine(string.Join(' ', ordersQue));
                    break;
                }

                ordersQue.Dequeue();
                foodAvailble-= currOrder;

            }

            if (ordersQue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }

        }
    }
}
