﻿using System;
using System.Linq;


namespace _03._Custom_Min_Function
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> findMin = s => s.Min();

            Console.WriteLine(findMin(Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray()));
             
            
        }
    }
}
