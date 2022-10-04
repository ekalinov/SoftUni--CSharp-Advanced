using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._List_Of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<int> dividers = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToList();

            
            List<int> numbers = new List<int>();

          
            Func<int, List<int>, List<int>> filter = (n, dividers) =>
           {
               List<int> result = new List<int>();

               for (int i = 1; i <= n; i++)
               {
                       bool isDiv = true;
                   foreach (var item in dividers)
                   {
                       if (i % item != 0)
                       {
                           isDiv = false;

                       }
                   }

                   if (isDiv) 
                       result.Add(i);
               }

               return result;

           };

            numbers = filter(n, dividers);

            

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
