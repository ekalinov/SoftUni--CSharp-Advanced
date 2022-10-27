using System;
using System.Collections.Generic;

namespace _05.ComparingObjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string cmd;
            while ((cmd=Console.ReadLine())!="END")
            {

                string[] peopleProps = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Person person = new Person(peopleProps[0], int.Parse(peopleProps[1]), peopleProps[2]);
                
                people.Add(person);


            }

            int peopleToCompereWith = int.Parse(Console.ReadLine());

            int diffPeopleCount=0;
            int equalPeopleCount=0;



            foreach (var person  in people)
            {
                if (people[peopleToCompereWith-1].CompareTo(person)!=0)
                {
                    diffPeopleCount++;
                }
                else
                {
                    equalPeopleCount++;
                }
               
            }

            if (equalPeopleCount==1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equalPeopleCount} {diffPeopleCount} {people.Count}");
            }



        }
    }
}
