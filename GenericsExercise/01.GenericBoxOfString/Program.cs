﻿using System;

namespace _01.GenericBoxOfString
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Box<string> newBox = new Box<string>() { ValueOfTheBox = Console.ReadLine()};

                Console.WriteLine(newBox.ToString());
            }

        }
    }
}
   