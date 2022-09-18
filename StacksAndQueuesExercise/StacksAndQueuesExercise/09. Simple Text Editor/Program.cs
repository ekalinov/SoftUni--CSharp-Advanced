using System;
using System.Collections.Generic;
using System.Text;

namespace _09._Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            StringBuilder sb   = new StringBuilder();

            Stack<string> operations = new Stack<string>();

            for (int i = 0; i < n; i++)
            {

                string[] cmdArgs = Console.ReadLine().Split();

                string cmd = cmdArgs[0];

                if (cmd == "1")
                {
                    //•	1 someString - appends someString to the end of the text
                    operations.Push(sb.ToString());
                    sb.Append(cmdArgs[1]);

                }
                else if (cmd == "2")
                {
                    //•	2 count - erases the last count elements from the text
                    int elementsCountToBeRemoved = int.Parse(cmdArgs[1]);

                    operations.Push(sb.ToString());
                    int startingIndex = sb.Length - elementsCountToBeRemoved;
                    sb.Remove(startingIndex, elementsCountToBeRemoved);
                }
                else if (cmd == "3")
                {
                    //•	3 index - returns the element at position index from the text
                    int indexToReturn = int.Parse(cmdArgs[1]);

                    Console.WriteLine(sb[indexToReturn-1]);
                }
                else if (cmd == "4")
                {
                    //•	4 - undoes the last not undone command of type 1 / 2 and returns the text to the state before that operation
                    sb.Clear ();
                        sb.Append(operations.Pop());

                }
            }


        }
    }
}
