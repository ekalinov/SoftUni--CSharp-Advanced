using System;
using System.Collections;
using System.Collections.Generic;

namespace ListyIterator
{
    public class ListyIterator<T> :IEnumerable<T>
    {

        private List<T> items;
        private int index;

        public ListyIterator(List<T> items)
        {

            this.items = items;
        }

        //•   Move - should move an internal index position to the next index in the list.
        //The method should return true, if it had successfully moved the index and false, if there is no next index.
        public bool Move()
        {
            if (index+1 < items.Count)
            {
                index++;
                return true;
            }

            return false;

        }
        //•   HasNext - should return true, if there is a next index and false,
        // if the index is already at the last element of the list
        public bool HasNext()
        {
            return index + 1 < items.Count;

        }

        //•   Print - should print the element at the current internal index.
        //Calling Print on a collection without elements should throw an appropriate exception with the message "Invalid Operation!". 

        public void Print()
        {
            if (items.Count==0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            Console.WriteLine(items[index]);
         }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in items)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
       
    }
}
