using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] lenghts = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int n = lenghts[0];
            int m = lenghts[1];

            HashSet<int> setN = new HashSet<int>();
            HashSet<int> setM = new HashSet<int>();
            HashSet<int>  matchingEl  = new HashSet<int>();


            for (int i = 0; i < n+m ; i++)
            {
                int element = int.Parse(Console.ReadLine());

                if (i<n)
                {
                    setN.Add(element);
                }
                else
                {
                    setM.Add(element);
                }

                //if (setN.Contains(element) && setM.Contains(element))
                //{
                //    matchingEl.Add(element);
                //}

            }


            setN.IntersectWith(setM);

            Console.WriteLine(string.Join(" ", setN));
        }
    }
}
