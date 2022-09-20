using System;
using System.Linq;

namespace _5._Square_With_Maximum_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] mtrxSize = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = mtrxSize[0];
            int cows = mtrxSize[1];
            int[,] mtrx = new int[rows, cows];


            for (int row = 0; row < mtrx.GetLength(0); row++)
            {
                int[] rawInput = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int cow = 0; cow < mtrx.GetLength(1); cow++)
                {
                    mtrx[row, cow] = rawInput[cow];
                }
            }


           int maxValue = 0;
            int maxSqStartingRow = 0;
            int maxSqStartingCow = 0;


            for (int row = 0; row < mtrx.GetLength(0)-1; row++)
            {
             
                for (int cow = 0; cow < mtrx.GetLength(1)-1; cow++)
                {
                    int currSqValue = mtrx[row, cow] + mtrx[row, cow+1]
                                    + mtrx[row+1, cow] + mtrx[row+1, cow + 1];


                    if (currSqValue>maxValue)
                    {
                        maxSqStartingRow = row;
                        maxSqStartingCow = cow;   
                        maxValue = currSqValue;

                    }
                }
            }


            for (int row = maxSqStartingRow; row < maxSqStartingRow+2; row++)
            {

                for (int cow = maxSqStartingCow; cow < maxSqStartingCow + 2; cow++)
                {
                    Console.Write(mtrx[row,cow]+ " ");
                }
            Console.WriteLine();
            }


            Console.WriteLine(maxValue);


        }
    }
}
