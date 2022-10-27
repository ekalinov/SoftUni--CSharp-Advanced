using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _03.Stack
{
    internal class Stack<T> : IEnumerable<T>
    {
        private List<T> elements;
        private int index;
        public Stack()
        {
            this.elements = new List<T>();
            index = -1;
        }

        public int Count => elements.Count;

        public void Push(List<T> elements)
        {
            foreach (var item in elements)
            {
                this.elements.Add(item);
                index++;
            }
        }

        public T Pop()
        {
            if (index < 0)
            {
                throw new NullReferenceException("No elements");
            }
            T popedElement = elements[index];

            elements.RemoveAt(index);

            index--;
            return popedElement;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = index; i >= 0; i--)
            {

                yield return elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
    }
}
