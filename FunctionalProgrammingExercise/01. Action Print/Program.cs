using System;

namespace _01._Action_Print
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> printer = s => Console.WriteLine(string.Join(Environment.NewLine,s));

            printer(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries));
        }
    }
}
