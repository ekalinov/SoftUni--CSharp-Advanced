using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            
            DoublyLinkedList<string> list = new DoublyLinkedList<string>();


            list.AddLast("sgags1gddsaaag");
            list.AddLast("sgagsaggs2saaag");
            list.AddLast("sgagsag3aaag");
            list.AddLast("sgagsa4gsaaag");


            list.AddFirst("sgagsa11gsaaag");
            list.AddFirst("sgagsagg22saaag");
            list.AddFirst("sgagsgda33aag");
            list.AddFirst("sgagsagg44saaag"); 
            list.AddFirst("sgagsad2245555551saaag");

            list.RemoveFirst();
            list.RemoveFirst();
            list.RemoveFirst();


            //list.ForEach(c => Console.WriteLine(c));

            string[] listToArr = list.ToArray();
            Console.WriteLine(String.Join(", ", listToArr));

        }
    }
}
