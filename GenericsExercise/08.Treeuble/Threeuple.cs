using System;
using System.Collections.Generic;
using System.Text;

namespace _08.Threeuple
{ 
    public class Threeuple<T1,T2,T3>
    {
        public T1 ElementOne { get; set; }
        public T2 ElementTwo { get; set; }
        public T3 ElementThree { get; set; }



        public Threeuple(T1 elementOne, T2 elementTwo, T3 elementThree)
        {
            ElementOne = elementOne;
            ElementTwo = elementTwo;
            ElementThree = elementThree;
        }

        public override string ToString()
        {
            return $"{ElementOne} -> {ElementTwo} -> {ElementThree}";
        }
    }
}
