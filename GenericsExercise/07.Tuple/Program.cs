using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Tuple
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
               Queue<string> nameAdress  = new Queue<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray());

                string name = $"{nameAdress.Dequeue()} {nameAdress.Dequeue()}";

                string adres = $"{string.Join(' ', nameAdress)}";
                                                    
               Tuple<string, string> tuple = new Tuple<string, string>(name, adres);

                

           string[] nameBeers =   Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            Tuple<string, int> tupleTwo = new Tuple<string, int>(nameBeers[0], int.Parse(nameBeers[1]));

            string[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            Tuple<int, double> tupleThree = new Tuple<int, double>(int.Parse(numbers[0]), double.Parse(numbers[1]));


            Console.WriteLine(tuple);
            Console.WriteLine(tupleTwo);
            Console.WriteLine(tupleThree);
        }
    }
}

