using System;
using System.Linq;

namespace _07.CustomComperator
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            Func<int,int,int> customComerator = (x,y) =>
            {
                if (x%2==0 && y%2 !=0)
                {
                    return -1;
                }
                if (x % 2 != 0 && y % 2 == 0)
                {
                    return 1;
                }
                if (x<y)
                {
                    return -1;
                }
                if (x > y)
                {
                    return 1;
                }
                return 0;
            };


            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Array.Sort(numbers, (x, y)=>customComerator(x,y));


            Console.WriteLine(String.Join(" ",numbers));

        }

        public void Sort()
        {

        }

    }
}
