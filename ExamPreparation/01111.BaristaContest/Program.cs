using System;
using System.Collections.Generic;
using System.Linq;

namespace _01111.BaristaContest
{
    internal class Program
    {
        class Bevareges
        {

            public Bevareges(string name, int quantity)
            {
                Name = name;
                Quantity = quantity;
                Times = 0;
            }

            public string Name { get; set; }
            public int Quantity { get; set; }
            public int Times { get; set; }

        }


        static void Main(string[] args)
        {

            List<Bevareges> bevareges = new List<Bevareges>()
            {
            new Bevareges("Cortado", 50),
            new Bevareges("Espresso", 75),
            new Bevareges("Capuccino", 100),
            new Bevareges("Americano", 150),
            new Bevareges("Latte", 200)
            };


            Queue<int> coffee = new Queue<int>(Console.ReadLine()
                                           .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                           .Select(int.Parse)
                                           .ToArray());

            Stack<int> milk = new Stack<int>(Console.ReadLine()
                                          .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                          .Select(int.Parse)
                                          .ToArray());




            while (coffee.Any() && milk.Any())
            {

                int coffeeQty = coffee.Dequeue();
                int milkQty = milk.Pop();

                int qty = milkQty + coffeeQty;


                if (bevareges.Any(x=>x.Quantity==qty))
                {
                    var bevarege = bevareges.First(x => x.Quantity == qty);

                    bevarege.Times++;
                }
                else
                {
                    milkQty -= 5;
                    milk.Push(milkQty);
                }

            }

            if (coffee.Any() || milk.Any())
            {
                Console.WriteLine($"Nina needs to exercise more! She didn't use all the coffee and milk!");
            }
            else
            {
                Console.WriteLine($"Nina is going to win! She used all the coffee and milk!");
            }

            string coffeeLeft = coffee.Any() ?  string.Join(", ",coffee) : "none";
            string milkLeft = milk.Any() ? string.Join(", ", milk) : "none";

            Console.WriteLine($"Coffee left: {coffeeLeft}");
            Console.WriteLine($"Milk left: {milkLeft}");

            foreach (var bevarege  in bevareges.Where(x=>x.Times!=0).OrderBy(x=>x.Times).ThenByDescending(x=>x.Name))
            {
                Console.WriteLine($"{bevarege.Name}: {bevarege.Times}");
            }


        }
    }
}
