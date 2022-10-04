using System;

namespace _02._Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> printer = s =>
            {
                foreach (var item in s)
                    Console.WriteLine($"Sir {item}");
            };

            printer(Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries));
        }
    }
}
