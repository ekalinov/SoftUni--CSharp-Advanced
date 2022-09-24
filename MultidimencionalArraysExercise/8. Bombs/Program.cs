using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Bombs
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


            //Create collection with the bombs
            Dictionary<int, string> bombs = new Dictionary<int, string>();

            string[] bombsPositions = Console.ReadLine().Split(" ");

            for (int i = 0; i < bombsPositions.Length; i++)
            {
                bombs.Add(i, bombsPositions[i]);
            }




            // Start explosions! 


            for (int i = 0; i < bombs.Count; i++)
            {
                int[] bombArgs = bombs[i].Split(",").Select(int.Parse).ToArray();
                int bombRow = bombArgs[0];
                int bombCol = bombArgs[1];

                if (mtrx[bombRow, bombCol] > 0)
                {
                    mtrx = Explode(mtrx, bombRow, bombCol, mtrxSize);
                    mtrx[bombRow, bombCol] = 0;
                }

            }

            SumOfAliveCells(mtrx);

            Print(mtrx);

        }



        private static int[,] Explode(int[,] mtrx, int row, int col, int size)
        {

            //Top left
            if (IsCellValid(row - 1, col - 1, size))
            {
                if (mtrx[row - 1, col - 1] > 0)
                {
                    mtrx[row - 1, col - 1] -= mtrx[row, col];
                }
            }
            //Top center
            if (IsCellValid(row - 1, col, size))
            {
                if (mtrx[row - 1, col] > 0)
                {
                    mtrx[row - 1, col] -= mtrx[row, col];
                }
            }
            //Top Right
            if (IsCellValid(row - 1, col + 1, size))
            {
                if (mtrx[row - 1, col + 1] > 0)
                {
                    mtrx[row - 1, col + 1] -= mtrx[row, col];
                }
            }

            //Middle left
            if (IsCellValid(row, col - 1, size))
            {
                if (mtrx[row, col - 1] > 0)
                {
                    mtrx[row, col - 1] -= mtrx[row, col];
                }
            }
            //Middle Right
            if (IsCellValid(row, col + 1, size))
            {
                if (mtrx[row, col + 1] > 0)
                {
                    mtrx[row, col + 1] -= mtrx[row, col];
                }
            }

            //Bottom left
            if (IsCellValid(row + 1, col - 1, size))
            {
                if (mtrx[row + 1, col - 1] > 0)
                {
                    mtrx[row + 1, col - 1] -= mtrx[row, col];
                }
            }
            //Bottom center
            if (IsCellValid(row + 1, col, size))
            {
                if (mtrx[row + 1, col] > 0)
                {
                    mtrx[row + 1, col] -= mtrx[row, col];
                }
            }
            //Bottom Right
            if (IsCellValid(row + 1, col + 1, size))
            {
                if (mtrx[row + 1, col + 1] > 0)
                {
                    mtrx[row + 1, col + 1] -= mtrx[row, col];
                }
            }


            return mtrx;
        }

        static bool IsCellValid(int row, int col, int size)
        {
            if (row >= 0 && row < size && col >= 0 && col < size)
            {
                return true;

            }

            return false;
        }

        static void SumOfAliveCells(int[,] mtrx)
        {
            int aliveCellsCounter = 0;
            int aliveCellsSum = 0;


            for (int row = 0; row < mtrx.GetLength(0); row++)
            {
                for (int col = 0; col < mtrx.GetLength(1); col++)
                {
                    if (mtrx[row, col] > 0)
                    {
                        aliveCellsCounter++;
                        aliveCellsSum += mtrx[row, col];
                    }

                }
            }

            Console.WriteLine($"Alive cells: {aliveCellsCounter}");
            Console.WriteLine($"Sum: {aliveCellsSum}");

        }


        private static void Print(int[,] mtrx)
        {
            for (int row = 0; row < mtrx.GetLength(0); row++)
            {
                for (int col = 0; col < mtrx.GetLength(1); col++)
                {
                    Console.Write(mtrx[row, col] + " ");

                }
                Console.WriteLine();
            }


        }

    }
}
