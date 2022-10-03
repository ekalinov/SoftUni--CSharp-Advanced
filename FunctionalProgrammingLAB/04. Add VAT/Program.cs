using System;
using System.Linq;

namespace _04._Add_VAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<double, string> addVAT = x => (x * 1.2D).ToString("F2");

            Console.WriteLine(string.Join(Environment.NewLine,
                Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(addVAT)));
               
        }
    }
}
