using System;

namespace LinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            DoublyLinkedList list = new DoublyLinkedList();


            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddLast(4);
            list.AddLast(5);


            list.AddFirst(10);
            list.AddFirst(20);
            list.AddFirst(30);
            list.AddFirst(40); 
            list.AddFirst(50);

            list.RemoveFirst();
            list.RemoveFirst();
            list.RemoveFirst();


            //list.ForEach(c => Console.WriteLine(c));

            int[] listToArr = list.ToArray();
            Console.WriteLine(String.Join(", ", listToArr));

        }
    }
}
