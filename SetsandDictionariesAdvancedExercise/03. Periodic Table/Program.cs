using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
           
           
            SortedSet<string> elements = new SortedSet<string>();

            for (int i = 0; i < n ; i++)
            {
                string[] elementsArr = Console.ReadLine().Split();

                foreach (var element in elementsArr)
                {
                    elements.Add(element);
                }

            }

            Console.WriteLine(string.Join(" ", elements));
        }
    }
}
