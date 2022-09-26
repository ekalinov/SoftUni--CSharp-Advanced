using System;
using System.Collections.Generic;

namespace _05._Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string input = Console.ReadLine();

           SortedDictionary<char, int> symbols = new SortedDictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                char currChar=input[i];

                if (!symbols.ContainsKey(currChar))
                {
                    symbols.Add(currChar, 0);
                }

                symbols[currChar]++;
            }

            foreach (var symbol in symbols)
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }







        }
    }
}
