using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Key_Revolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barelCapacity = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] locks = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int intelligenceValue = int.Parse(Console.ReadLine());

            Queue<int> locksQueue = new Queue<int>(locks);

            Stack<int> bulletsStack = new Stack<int>(bullets);


           
            int shots = 0;

            while (bulletsStack.Any() && locksQueue.Any())
            {
                int currentLock = locksQueue.Peek();
                shots++;
                


                if (currentLock >= bulletsStack.Pop())
                {
                    locksQueue.Dequeue();
                    Console.WriteLine("Bang!");
                }
                else
                    Console.WriteLine("Ping!");

                if (shots % barelCapacity==0 && bulletsStack.Any())
                {
                    Console.WriteLine("Reloading!");
                }

              

                if (shots == bullets.Count())
                {
                    break;
                }


            }

            if (locksQueue.Any())
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count}");
            }
            else
            {

                int inteligence = intelligenceValue - (shots * bulletPrice);

                Console.WriteLine($"{bulletsStack.Count} bullets left. Earned ${inteligence}");

            }




        }
    }
}
