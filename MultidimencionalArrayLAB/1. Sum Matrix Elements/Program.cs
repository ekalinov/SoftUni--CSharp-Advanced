using System;
using System.Linq;

namespace _1._Sum_Matrix_Elements
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


            Console.WriteLine(mtrx.GetLength(0));
            Console.WriteLine(mtrx.GetLength(1));

            int sum = 0;

            for (int row = 0; row < mtrx.GetLength(0); row++)
            {
                for (int cow = 0; cow < mtrx.GetLength(1); cow++)
                {
                    sum+=mtrx[row, cow];

                }
            }

            Console.WriteLine(sum);

        }
    }
}
