using System;
using System.Collections.Generic;
using System.Text;

namespace _01.GenericBoxOfString
{
    public class Box <T>
    {

        private T valueOfTheBox;

       
        public T ValueOfTheBox
        {
            get { return valueOfTheBox; }
            set { valueOfTheBox = value; }
        }

        public override string ToString()
        {
            return $"{typeof(T)}: {ValueOfTheBox}";
        }

    }
}
