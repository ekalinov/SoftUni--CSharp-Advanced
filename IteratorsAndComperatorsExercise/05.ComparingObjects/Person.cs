using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _05.ComparingObjects
{
    internal class Person : IComparable<Person> 
    {
        private List<Person> people;
        private string name;
        private int age;
        private string town;

        public Person(string name, int age, string town)
        {
            this.name = name;
            this.age = age;
            this.town = town;
        }

        public int CompareTo(Person other)
        {
            if (this.name != other.name)
            {
                return -1;
            }

            if (this.age != other.age)
            {
                return 1;
            }

            if (this.town!=other.town)
            {
                return -1;
            }

            return 0;
        }
    }
}
