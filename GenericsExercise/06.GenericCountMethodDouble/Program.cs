using System;

namespace _06.GenericCountMethodDouble
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Box<double> newBox = new Box<double>();

            for (int i = 0; i < n; i++)
            {
                double input = double.Parse(Console.ReadLine());

                newBox.list.Add(input);
            }

            double comperator = double.Parse(Console.ReadLine());

            int count = newBox.CountGreater(comperator);

            Console.WriteLine(count);
        }
    }
}
