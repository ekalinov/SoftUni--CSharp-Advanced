using System;
using System.Linq;

namespace _05.GenericCountMethodString
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Box<string> newBox = new Box<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                newBox.list.Add(input);
            }

            string comperator = Console.ReadLine();

           int count =  newBox.CountGreater(comperator);

             Console.WriteLine(count);
        }
    }
}
