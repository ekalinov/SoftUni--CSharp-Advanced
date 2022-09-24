using System;
using System.Linq;

namespace _000.Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {  
            
            
            
            // Input and building the matrix !
            int mtrxSize = int.Parse(Console.ReadLine());

            int[,] mtrx = new int[mtrxSize, mtrxSize];

            for (int row = 0; row < mtrx.GetLength(0); row++)
            {
                int[] rawInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < mtrx.GetLength(1); col++)
                {
                    mtrx[row, col] = rawInput[col];
                }
            }


            int[,] mtrxNew = new int[mtrxSize, mtrxSize];

            mtrxNew = mtrx;



            mtrxNew[0,0] = 0;
            mtrxNew[1, 0] = 0;
            mtrxNew[2, 0] = 0;
            mtrxNew[0, 1] = 0;
            mtrx = mtrxNew;

        }
    }
}
