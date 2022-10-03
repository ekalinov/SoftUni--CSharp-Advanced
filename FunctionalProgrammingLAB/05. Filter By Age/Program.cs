using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Filter_By_Age
{
    internal class Program
    {
        public class Person
        {
            public int Age { get; set; }
            public string Name { get; set; }
        }

        static void Main(string[] args)
        {
            //Read given n people 
            List<Person> people = ReadPeople();

            // Read given Condition 
            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            //Filter people
            Func<Person, bool> filter = CreateAgeFilter(condition, age);

            List<Person> matchngPeople = people
                                           .Where(filter)
                                           .ToList();

            //Print people matching the condition in correct format pattern 
            string printFormat = Console.ReadLine();

            Action<Person> formater =
                                    CreatPeoplePrinter(printFormat);

            PrintPeople(matchngPeople, formater);



        }

        private static void PrintPeople(List<Person> matchngPeople, Action<Person> formater)
        {
            foreach (var p in matchngPeople)
            {
                formater(p);
            }
        }

        private static Action<Person> CreatPeoplePrinter(string printFormat)
        {
            if (printFormat == "name age")
            {
                return p => Console.WriteLine($"{p.Name} - {p.Age}");
            }
            else if (printFormat == "name")
            {
                return p => Console.WriteLine($"{p.Name}");
            }
            else if (printFormat == "name")
            {
                return p => Console.WriteLine($"{p.Age}");
            }
            throw new NotImplementedException();
        }

        private static Func<Person, bool> CreateAgeFilter(string condition, int age)
        {
            if (condition == "older")
            {
                return p => p.Age >= age;
            }
            else
                return p => p.Age < age;

        }

        static List<Person> ReadPeople()
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] strings = Console.ReadLine()
                                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                Person person = new Person();

                person.Age = int.Parse(strings[1]);
                person.Name = strings[0];

                people.Add(person);

            }
            return people;
        }
    }
}
