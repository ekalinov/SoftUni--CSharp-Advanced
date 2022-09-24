using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _9._Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //input and creating the field and collection with moves

            int mtrxSize = int.Parse(Console.ReadLine());

            Queue<string> moves = new Queue<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));



            char[,] mtrx = new char[mtrxSize, mtrxSize];

            for (int row = 0; row < mtrx.GetLength(0); row++)
            {
                string[] rawInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < mtrx.GetLength(1); col++)
                {
                    mtrx[row, col] = char.Parse(rawInput[col]);
                }
            }

            //Finding starting position and how many coals we have on the fiels
            int startingPosRow = 0;
            int startingPosCol = 0;

            int coalsCount = 0;

            for (int row = 0; row < mtrx.GetLength(0); row++)
            {
                for (int col = 0; col < mtrx.GetLength(1); col++)
                {
                    if (mtrx[row, col] == 's')
                    {
                        startingPosRow = row;
                        startingPosCol = col;
                    }

                    if (mtrx[row, col] == 'c')
                    {
                        coalsCount++;
                    }
                }
            }


            //We move until we finish our moves, step on "e" or we collect all coals! 

            int currPositionRow = startingPosRow;
            int currPositionCol = startingPosCol;
            while (true)
            {

                if (mtrx[currPositionRow, currPositionCol] != 'e' && moves.Count>0)
                {
                    string currMove = moves.Dequeue();
                    int[] newPosition = MoveMethod(currMove, currPositionRow, currPositionCol, mtrx, mtrxSize);

                    currPositionRow = newPosition[0];
                    currPositionCol = newPosition[1];

                }
                else
                {
                    Console.WriteLine($"Game over! ({currPositionRow}, {currPositionCol})");
                    break;
                }

                if (mtrx[currPositionRow, currPositionCol] == 'c')
                {
                    coalsCount--;
                    mtrx[currPositionRow, currPositionCol] = '*';

                    if (coalsCount == 0)
                    {
                        Console.WriteLine($"You collected all coals! ({currPositionRow}, {currPositionCol})");
                        break;
                    }
                }

                if (moves.Count == 0 && mtrx[currPositionRow, currPositionCol] != 'e')
                {
                    Console.WriteLine($"{coalsCount} coals left. ({currPositionRow}, {currPositionCol})");
                    break;
                }


            }



        }

        private static int[] MoveMethod(string currMove, int startR, int startC, char[,] mtrx, int mtrxSize)
        {
            int currPositionR = startR;
            int currPositionC = startC;


            //  up
            if (currMove == "up")
            {
                if (IsCellValid(currPositionR - 1, currPositionC, mtrxSize))
                {
                    currPositionR--;
                }
            }
            // down
            if (currMove == "down")
            {
                if (IsCellValid(currPositionR + 1, currPositionC, mtrxSize))
                {
                    currPositionR++;
                }
            }
            // left
            if (currMove == "left")
            {
                if (IsCellValid(currPositionR, currPositionC - 1, mtrxSize))
                {
                    currPositionC--;
                }
            }
            // right
            if (currMove == "right")
            {
                if (IsCellValid(currPositionR, currPositionC + 1, mtrxSize))
                {
                    currPositionC++;
                }
            }




            int[] newPosition = new int[2] { currPositionR, currPositionC };

            return newPosition;
        }

        static bool IsCellValid(int row, int col, int size)
        {
            if (row >= 0 && row < size && col >= 0 && col < size)
            {
                return true;
            }

            return false;
        }
    }
}

