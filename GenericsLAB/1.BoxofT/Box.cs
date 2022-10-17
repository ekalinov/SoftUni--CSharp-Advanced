using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> elements;

        

        public Box()
        {
          this.elements = new List<T>();
        }

        public int Count { get { return elements.Count; } }


        public void Add(T element)
        {
            this.elements.Add(element);
        }

        public T Remove()
        {
            T elementToRemove = elements[elements.Count - 1];
            elements.RemoveAt(elements.Count - 1);
            return elementToRemove;

        }

    }
}
