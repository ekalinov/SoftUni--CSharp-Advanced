using System;
using System.Linq;

namespace _3._Primary_Diagonal
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



                int sum = 0;
            for (int cow = 0; cow < mtrx.GetLength(1); cow++)
            {

                for (int row = 0; row < mtrx.GetLength(0); row++)
                {
                    if (row==cow)
                    {
                    sum += mtrx[row, cow];

                    }

                }
            }

                Console.WriteLine(sum);
        }
    }
}
