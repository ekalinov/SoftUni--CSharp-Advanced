using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Tuple
{
    public class Tuple<T1,T2>
    {
        public T1 ElementOne { get; set; }
        public T2 ElementTwo { get; set; }

        public Tuple(T1 elementOne, T2 elementTwo)
        {
            ElementOne = elementOne;
            ElementTwo = elementTwo;
        }

        public override string ToString()
        {
            return $"{ElementOne} -> {ElementTwo}";
        }
    }
}
