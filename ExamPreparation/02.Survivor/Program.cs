using System;
using System.Collections.Generic;
using System.Linq;

namespace _0222.Survivor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int myTokens = 0;
            int opponentsTokens = 0;

            int n = int.Parse(Console.ReadLine());

            char[][] mtrx = new char[n][];

            for (int row = 0; row < mtrx.GetLength(0); row++)
            {
                char[] rowInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                                    .Select(char.Parse)
                                                    .ToArray();

                mtrx[row] = new char[rowInput.Length];

                for (int cow = 0; cow < rowInput.Length; cow++)
                {
                    mtrx[row][cow] = rowInput[cow];

                }
            }


            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Gong")
                {
                    break;
                }

                string[] cmdArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = cmdArgs[0];
                int searchedR = int.Parse(cmdArgs[1]);
                int searchedC = int.Parse(cmdArgs[2]);

                switch (command)
                {
                    case "Find":

                        if (IsCellValid(searchedR, searchedC, mtrx))
                        {
                            myTokens = Find(searchedR, searchedC, mtrx, myTokens);
                        }
                        break;

                    case "Opponent":


                        if (IsCellValid(searchedR, searchedC, mtrx))
                        {
                            opponentsTokens = OpponeneMethod(searchedR, searchedC, mtrx, opponentsTokens, cmdArgs[3]);
                        }

                        break;
                }

            }

            Print(mtrx);

            Console.WriteLine($"Collected tokens: {myTokens}");

            Console.WriteLine($"Opponent's tokens: {opponentsTokens}"); 





        }
        private static int Find(int searchedR, int searchedC, char[][] mtrx, int myTokens)
        {
            //•	"Find {row} {col}":
            //o You have to go to the given place if it is valid and collect the token, if there is one.
            //o When you collect it, you have to mark the place as an empty, using dash symbol.

            if (mtrx[searchedR][searchedC] == 'T')
            {
                mtrx[searchedR][searchedC] = '-';
                myTokens++;
            }

            return myTokens;
        }

        private static int OpponeneMethod(int searchedR,
                                          int searchedC,
                                          char[][] mtrx,
                                          int opponentsTokens,
                                          string direction)
        {

            //o One of your opponents is searching for a token at the given coordinates if they exist.
            //o After going at the given coordinates(if they exist) and collecting the token(if there is such),
            //the opponent is beginning a movement in the given direction by 3 steps.
            //He collects all the tokens that are placed on his way.
            //o If opponent's movement is going to step outside of the field, he is stepping only on the possible indexes.
            //o When he finds tokens, he marks the cells as empty.
            //o   There are four possible directions, in which he can go: "up", "down", "left", "right".

            if (mtrx[searchedR][searchedC] == 'T')
            {
                mtrx[searchedR][searchedC] = '-';
                opponentsTokens++;
            }

            for (int i = 1; i <= 3; i++)
            {

                int[] newPosition = MoveMethod(direction, searchedR, searchedC);

                int newR = newPosition[0];
                int newC = newPosition[1];

                if (IsCellValid(newR, newC, mtrx))
                {
                    if (mtrx[newR][newC] == 'T')
                    {
                        mtrx[newR][newC] = '-';
                        opponentsTokens++;
                    }

                }

                searchedR = newR;
                searchedC = newC;
            }

            return opponentsTokens;
        }


        private static bool IsCellValid(int row, int col, char[][] mtrx)
        {
            if (row >= 0 && row < mtrx.GetLength(0) && col >= 0 && col < mtrx[row].Length)
            {
                return true;
            }
            return false;
        }

        private static int[] MoveMethod(string currMove, int startR, int startC)
        {

            int currPositionR = startR;
            int currPositionC = startC;

            //  up
            if (currMove == "up")
            {
                currPositionR--;
            }
            // down
            if (currMove == "down")
            {
                currPositionR++;
            }
            // left
            if (currMove == "left")
            {
                currPositionC--;
            }
            // right
            if (currMove == "right")
            {
                currPositionC++;
            }

            int[] newPosition = new int[2] { currPositionR, currPositionC };

            return newPosition;
        }


        private static void Print(char[][] mtrx)
        {
            for (int row = 0; row < mtrx.GetLength(0); row++)
            {
                    Console.WriteLine(string.Join(" ",mtrx[row]));
            }

        }
    }
}
