using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{ 
    public class Family
    {
        private List<Person> members;

        public Family()
        {
            Members = new List<Person>();
        }

        public List<Person> Members
        {
            get { return members; }
            set { members = value; }
        }


        public void AddMember(Person member)
        {
           Members.Add(member);
        }

        public Person GetOldestMember()
        {
            int oldestMember = int.MinValue;
            Person oldestPerson = null;

            foreach (Person member in Members)
            {
                if (member.Age>oldestMember)
                {
                    oldestMember = member.Age;
                    oldestPerson = member;
                }
            }
            return oldestPerson;
        }

    }
}
