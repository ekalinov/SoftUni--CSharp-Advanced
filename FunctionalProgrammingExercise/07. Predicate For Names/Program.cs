using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Predicate_For_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                       

            Predicate<int> lenghtFilter = number => number <= lenght ;


            Func<List<string>,Predicate<int>, List<string>> filter = (names, lenghtFilter) =>
            {
                List<string> result = new List<string>();

                foreach (string s in names)
                if (lenghtFilter(s.Length))
                {
                        result.Add(s);
                }

                return result;
            } ;


            List<string> result = filter(names, lenghtFilter);
           

            Console.WriteLine(string.Join(Environment.NewLine, result));


        }
    }
}
