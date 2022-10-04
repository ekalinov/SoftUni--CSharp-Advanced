using System;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {


            int[] numbers = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int, int> add = num => num + 1;
            Func<int, int> multiply = num => num * 2;
            Func<int, int> subtract = num => num - 1;
            Action<int[]> print = nums => Console.WriteLine(String.Join(" ", nums));


            while (true)
            {string cmd = Console.ReadLine();
                if (cmd== "end")
                {
                    break;
                }

                switch (cmd)
                {
                    case "add":
                        numbers = numbers.Select(x => add(x)).ToArray();
                        break;
                    case "multiply":
                        numbers = numbers.Select(x => multiply(x)).ToArray();
                        break;
                    case "subtract":
                        numbers = numbers.Select(x => subtract(x)).ToArray();
                        break;
                    case "print":
                       print(numbers);
                        break;
                }
            }








            //•	"add"->add 1 to each number
            //•	"multiply"->multiply each number by 2
            //•	"subtract"->subtract 1 from each number
            //•	"print"->print the collection
            //•	"end"->ends the input

        }
    }
}
