using System;

namespace _02.GenericBoxOfIntegers
{
    public   class StartPp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Box<int> newBox = new Box<int>() { ValueOfTheBox = int.Parse(Console.ReadLine()) };

                Console.WriteLine(newBox.ToString());
            }

        }
    }
}
