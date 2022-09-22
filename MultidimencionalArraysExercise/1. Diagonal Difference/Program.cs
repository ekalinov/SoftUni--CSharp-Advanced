using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {


            int mtrxSize = int.Parse(Console.ReadLine());

            int[,] mtrx = new int[mtrxSize, mtrxSize];

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

            int sumPrimery = 0;
            int sumSecondary = 0;


            for (int row = 0; row < mtrx.GetLength(0); row++)
            {
                for (int cow = 0; cow < mtrx.GetLength(1); cow++)
                {
                    int currRow = row; 
                    int currCol = cow;

                    if (currRow == row && currCol == mtrxSize-1- currRow)
                    {
                        sumSecondary += mtrx[row, cow];
                    }


                    if (row == cow)
                    {
                        sumPrimery += mtrx[row, cow];
                    }

                }   
            }



            Console.WriteLine(Math.Abs(sumPrimery-sumSecondary));
         

        }
    }
}
