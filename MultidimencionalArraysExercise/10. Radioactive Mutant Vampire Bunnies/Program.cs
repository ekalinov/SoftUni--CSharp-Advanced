using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] mtrxSize = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            char[,] mtrx = new char[mtrxSize[0], mtrxSize[1]];

            for (int row = 0; row < mtrx.GetLength(0); row++)
            {
                string rawInput = Console.ReadLine();

                for (int col = 0; col < mtrx.GetLength(1); col++)
                {
                    mtrx[row, col] = rawInput[col];
                }
            }


            Queue<char> moves = new Queue<char>();

            string movesPattern = Console.ReadLine();

            foreach (char item in movesPattern)
            {
                moves.Enqueue(item);
            }



            //Finding starting position of the player
            int startingPosRow = 0;
            int startingPosCol = 0;

            for (int row = 0; row < mtrx.GetLength(0); row++)
            {
                for (int col = 0; col < mtrx.GetLength(1); col++)
                {
                    if (mtrx[row, col] == 'P')
                    {
                        startingPosRow = row;
                        startingPosCol = col;
                    }

                }
            }

            //We move until we leave the field or a bunnie kills us 
            int currPositionRow = startingPosRow;
            int currPositionCol = startingPosCol;

            while (true)
            {

                char currMove = moves.Dequeue();

                Stack<int[]> lastPosition = new Stack<int[]>();

                int[] lastPos = new int[2] { currPositionRow, currPositionCol };
                lastPosition.Push(lastPos);


                int[] newPosition = MoveMethod(currMove, currPositionRow, currPositionCol, mtrx);

                currPositionRow = newPosition[0];

                currPositionCol = newPosition[1];



                if (IsCellValid(currPositionRow, currPositionCol, mtrxSize[0], mtrxSize[1]))
                {
                    if (mtrx[currPositionRow, currPositionCol] != 'B')
                        mtrx[currPositionRow, currPositionCol] = 'P';
                }

                int[] lastMove = lastPosition.Peek();
                int lastRow = lastMove[0];
                int lastCol = lastMove[1];

                mtrx[lastRow, lastCol] = '.';

                mtrx = BunnysSpreadMethod(mtrx);

                if (!IsCellValid(currPositionRow, currPositionCol, mtrxSize[0], mtrxSize[1]))
                {
                    Print(mtrx);

                    lastMove = lastPosition.Peek();
                    lastRow = lastMove[0];
                    lastCol = lastMove[1];

                    Console.WriteLine($"won: {lastRow} {lastCol}");
                    break;
                }

                if (mtrx[currPositionRow, currPositionCol] == 'B')
                {
                    Print(mtrx);
                    Console.WriteLine($"dead: {currPositionRow} {currPositionCol}");
                    break;
                }

            }





        }

        private static int[] MoveMethod(char currMove, int startR, int startC, char[,] mtrx)
        {

            int currPositionR = startR;
            int currPositionC = startC;

            //  up
            if (currMove == 'U')
            {
                currPositionR--;
            }
            // down
            if (currMove == 'D')
            {
                currPositionR++;
            }
            // left
            if (currMove == 'L')
            {
                currPositionC--;
            }
            // right
            if (currMove == 'R')
            {
                currPositionC++;
            }

            int[] newPosition = new int[2] { currPositionR, currPositionC };

            return newPosition;
        }

        private static char[,] BunnysSpreadMethod(char[,] mtrx)
        {
            int rows = mtrx.GetLength(0);
            int cols = mtrx.GetLength(1);


            char[,] mtrxCurr = CopyMatrix(mtrx);



            for (int row = 0; row < mtrx.GetLength(0); row++)
            {
                for (int col = 0; col < mtrx.GetLength(1); col++)
                {

                    if (mtrx[row, col] == 'B')
                    {
                        //Top center
                        if (IsCellValid(row - 1, col, rows, cols))
                        {
                            if (mtrx[row - 1, col] != 'B')
                            {
                                mtrxCurr[row - 1, col] = 'B';
                            }
                        }
                        //Middle left
                        if (IsCellValid(row, col - 1, rows, cols))
                        {
                            if (mtrx[row, col - 1] != 'B')
                            {
                                mtrxCurr[row, col - 1] = 'B';
                            }
                        }
                        //Middle Right
                        if (IsCellValid(row, col + 1, rows, cols))
                        {
                            if (mtrx[row, col + 1] != 'B')
                            {
                                mtrxCurr[row, col + 1] = 'B';
                            }
                        }
                        //Bottom center
                        if (IsCellValid(row + 1, col, rows, cols))
                        {
                            if (mtrx[row + 1, col] != 'B')
                            {
                                mtrxCurr[row + 1, col] = 'B';
                            }
                        }
                    }

                }
            }
            return mtrxCurr; ;
        }

        private static char[,] CopyMatrix(char[,] mtrx)
        {

            char[,] copy = new char[mtrx.GetLength(0), mtrx.GetLength(1)];
            for (int row = 0; row < mtrx.GetLength(0); row++)
            {
                for (int col = 0; col < mtrx.GetLength(1); col++)
                {
                    copy[row, col] = mtrx[row, col];

                }
            }
            return copy;

        }

        private static bool IsCellValid(int row, int col, int rows, int cols)
        {
            if (row >= 0 && row < rows && col >= 0 && col < cols)
            {
                return true;
            }
            return false;
        }

        private static void Print(char[,] mtrx)
        {
            for (int row = 0; row < mtrx.GetLength(0); row++)
            {
                for (int col = 0; col < mtrx.GetLength(1); col++)
                {
                    Console.Write(mtrx[row, col]);

                }
                Console.WriteLine();
            }


        }
    }
}
