using System;
using System.Linq;

namespace _2._Squares_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] mtrxSize = Console.ReadLine()
                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse)
                                        .ToArray();
            int rows = mtrxSize[0];
            int cols = mtrxSize[1];


            int[,] mtrx = new int[rows, cols];

            for (int row = 0; row < mtrx.GetLength(0); row++)
            {
                char[] rawInput = Console.ReadLine()
                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                        .Select(char.Parse)
                                        .ToArray();

                for (int cow = 0; cow < mtrx.GetLength(1); cow++)
                {


                    mtrx[row, cow] = rawInput[cow];

                }
            }


            int counterOfMatches = 0;

            for (int row = 0; row < mtrx.GetLength(0)-1; row++)
            {

                for (int cow = 0; cow < mtrx.GetLength(1)-1; cow++)
                {
                    if (mtrx[row, cow] == mtrx[row, cow + 1] &&
                        mtrx[row, cow] == mtrx[row+1, cow] &&
                        mtrx[row, cow] == mtrx[row+1, cow + 1] )
                    {
                        counterOfMatches++;
                    }

                }
            }


            Console.WriteLine(counterOfMatches);




        }
    }
}
