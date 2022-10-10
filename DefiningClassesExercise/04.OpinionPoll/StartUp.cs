using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();


            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] memberArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);


                Person person = new Person(memberArgs[0], int.Parse(memberArgs[1]));

                people.Add(person);
            }

            var orderedList = people.Where(p => p.Age > 30).OrderBy(p => p.Name);

            foreach (var person in orderedList)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }



        }
    }
}
