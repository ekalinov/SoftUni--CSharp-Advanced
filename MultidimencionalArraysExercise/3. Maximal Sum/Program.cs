using System;
using System.Linq;

namespace _3._Maximal_Sum
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
                int[] rawInput = Console.ReadLine()
                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse)
                                        .ToArray();

                for (int cow = 0; cow < mtrx.GetLength(1); cow++)
                {


                    mtrx[row, cow] = rawInput[cow];

                }
            }

            int maxValue = 0;
            int maxVMatrixRow = 0;
            int maxVMatrixCol = 0;

            for (int row = 0; row < mtrx.GetLength(0) - 2; row++)
            {

                for (int cow = 0; cow < mtrx.GetLength(1) - 2; cow++)
                {
                    int sum = mtrx[row, cow] + mtrx[row, cow + 1] + mtrx[row, cow + 2] +
                       mtrx[row + 1, cow] + mtrx[row + 1, cow + 1] + mtrx[row + 1, cow + 2] +
                       mtrx[row + 2, cow] + mtrx[row + 2, cow + 1] + mtrx[row + 2, cow + 2];

                    if (sum > maxValue)
                    {
                        maxValue = sum;
                        maxVMatrixRow = row;
                        maxVMatrixCol = cow;

                    }

                }
            }

            Console.WriteLine($"Sum = {maxValue}");

            for (int row = maxVMatrixRow; row < maxVMatrixRow+3; row++)
            {

                for (int cow = maxVMatrixCol; cow < maxVMatrixCol + 3; cow++)
                {
                    Console.Write(mtrx[row,cow]+" ");
                }
                Console.WriteLine();
            }


        }
    }
}
