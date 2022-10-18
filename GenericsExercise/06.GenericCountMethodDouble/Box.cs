using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06.GenericCountMethodDouble
{

    public class Box <T> where T : IComparable
    {

        private T valueOfTheBox;
        public List<T> list;

        public Box()
        {
            list= new List<T>();
        }
       

        public T ValueOfTheBox
        {
            get { return valueOfTheBox; }
            set { valueOfTheBox = value; }
        }

        public override string ToString()
        {   StringBuilder sb = new StringBuilder();

            foreach (var item in list)
            {
                sb.AppendLine($"{typeof(T)}: {item}");
            }

            return sb.ToString().Trim();
        }

        public void  SwapMethod(int index1, int index2) 
        {
            T element1 = list[index1];
            T element2 = list[index2];

            list.RemoveAt(index1);
            list.Insert(index1, element2);
            list.RemoveAt(index2);
            list.Insert(index2, element1);

        }

        public int CountGreater(T element) 
        {

            int count = list.Where(x=>x.CompareTo(element)==1).Count();



            return count;
        }

    }
}
