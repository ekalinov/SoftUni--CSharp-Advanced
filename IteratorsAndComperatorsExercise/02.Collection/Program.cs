﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Collection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                                   .Skip(1)
                                                   .ToList();


            ListyIterator<string> listyIterator = new ListyIterator<string>(items);

            string cmd;
            while ((cmd = Console.ReadLine()) != "END")
            {
                switch (cmd)
                {
                    case "Move":

                        Console.WriteLine(listyIterator.Move());

                        break;
                    case "HasNext":

                        Console.WriteLine(listyIterator.HasNext());

                        break;
                    case "Print":
                        try
                        {
                            listyIterator.Print();

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;
                    case "PrintAll":
                        foreach (var item in listyIterator)
                        {
                            Console.Write($"{item} ");
                        }
                        Console.WriteLine();
                        break;


                }
            }





        }
    }
}
