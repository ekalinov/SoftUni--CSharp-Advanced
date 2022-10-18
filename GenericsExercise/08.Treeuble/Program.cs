using System;
using System.Collections.Generic;

namespace _08.Threeuple
{
    public class Program
    {
        static void Main(string[] args)
        {

            Queue<string> nameAdress = new Queue<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));

            string name = $"{nameAdress.Dequeue()} {nameAdress.Dequeue()}";

            string adress = nameAdress.Dequeue();

            string town = $"{string.Join(' ', nameAdress)}";

            Threeuple<string, string, string> tuple = new Threeuple<string, string, string>(name, adress, town);



            string[] nameBeers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            bool drunkOrNot = nameBeers[2]=="drunk" ? true : false;

            Threeuple<string, int, bool> tupleTwo = new Threeuple<string, int, bool>(nameBeers[0], int.Parse(nameBeers[1]), drunkOrNot);






            string[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Threeuple<string, double, string> tupleThree = new Threeuple< string, double, string> (numbers[0], double.Parse(numbers[1]), numbers[2]);


            Console.WriteLine(tuple);
            Console.WriteLine(tupleTwo);
            Console.WriteLine(tupleThree);
        }
    }
}
