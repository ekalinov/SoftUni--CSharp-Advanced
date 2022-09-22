using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int mtrxSize = int.Parse(Console.ReadLine());


            int[][] mtrx = new int[mtrxSize][];


            for (int row = 0; row < mtrx.GetLength(0); row++)
            {
                mtrx[row] = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            }

            //Analyze! 

            AnalizeMAtrixMethod(mtrx);

            //•	"Add {row} {column} {value}" - add { value}
            //            to the element at the given indexes, if they are valid.
            //•	"Subtract {row} {column} {value}" - subtract { value}
            //            from the element at the given indexes, if they are valid.
            //•	"End" - print the final state of the matrix(all elements separated by a single space) and stop the program.



            while (true)
            {
                string[] cmdArgs = Console.ReadLine().Split(' ');

                if (cmdArgs[0].ToLower() == "end")
                {
                    break;
                }

                int row = int.Parse(cmdArgs[1]);
                int col = int.Parse(cmdArgs[2]);
                int value = int.Parse(cmdArgs[3]);

                if (row<0 || row>= mtrx.GetLength(0) ||col<0 || col >= mtrx[row].Length)
                {
                    continue;
                }

                string cmd=cmdArgs[0].ToLower();

                switch (cmd)
                {
                    case "add":
                        mtrx[row][col] += value;

                    break;
                    case "subtract":

                        mtrx[row][col] -= value;
                        break;

                }

            }


            for (int i = 0; i < mtrx.GetLength(0); i++)
            {

                Console.WriteLine(string.Join(" ", mtrx[i]));


            }



        }

        private static void AnalizeMAtrixMethod(int[][] mtrx)
        {
            for (int row = 0; row < mtrx.GetLength(0) - 1; row++)
            {
                int[] currRow = mtrx[row];
                int[] nextRow = mtrx[row + 1];

                if (currRow.Length == nextRow.Length)
                {
                    currRow = currRow.Select(x => x *= 2).ToArray();
                    nextRow = nextRow.Select(x => x *= 2).ToArray();

                }
                else
                {
                    currRow = currRow.Select(x => x /= 2).ToArray();
                    nextRow = nextRow.Select(x => x /= 2).ToArray();
                }

                mtrx[row] = currRow;
                mtrx[row + 1] = nextRow;

            }
               
        }
    }
}
