using System;

namespace _01._Smallest_of_Three_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            int SmallestNum = Smallest(a, b, c);
            Console.WriteLine(SmallestNum);
        }

        static int Smallest(int a, int b, int c)
        {
            int Small = 0;
            if (a <= b && a <= c)
            {
                Small = a;
            }
            if (b <= a && b <= c)
            {
                Small = b;
            }
            if (c <= a && c <= b)
            {
                Small = c;
            }
            return Small;
        }
    }
}