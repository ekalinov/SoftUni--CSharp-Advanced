using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] memberArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);


                Person person = new Person(memberArgs[0], int.Parse(memberArgs[1]));

                family.AddMember(person);
            }

            Console.WriteLine($"{family.GetOldestMember().Name} {family.GetOldestMember().Age}");




        }
    }
}
