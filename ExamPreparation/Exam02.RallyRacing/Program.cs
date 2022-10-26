using System;
using System.Linq;

namespace Exam2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string carNum = Console.ReadLine();


            char[,] mtrx = new char[n, n];

            bool isFirstTunnle = true;
            int currRow = 0;
            int currCol = 0;

            int tunnelAR = 0;
            int tunnelAC = 0;

            int tunnelBR = 0;
            int tunnelBC = 0;

            for (int row = 0; row < mtrx.GetLength(0); row++)
            {
                char[] rowInput = Console.ReadLine()
                                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                            .Select(char.Parse)
                                            .ToArray();

                for (int col = 0; col < mtrx.GetLength(0); col++)
                {
                    mtrx[row, col] = rowInput[col];

                    if (rowInput[col] == 'T')
                    {
                        if (isFirstTunnle)
                        {
                            tunnelAR = row;
                            tunnelAC = col;
                            isFirstTunnle = false;
                            continue;
                        }
                        tunnelBR = row;
                        tunnelBC = col;
                    }

                }

            }


            int kilometers = 0;

            while (true)
            {
                string command = Console.ReadLine().ToLower();

                if (command == "end")
                {
                    mtrx[currRow, currCol] = 'C';
                    Console.WriteLine($"Racing car {carNum} DNF.");
                    break;
                }


                int[] newPosition = MoveMethod(command, currRow, currCol);

                kilometers += 10;

                currRow = newPosition[0];
                currCol = newPosition[1];

                if (mtrx[currRow, currCol] == 'T')
                {
                    mtrx[currRow, currCol] = '.';
                    if (currRow == tunnelAR && currCol == tunnelAC)
                    {
                        currRow = tunnelBR;
                        currCol = tunnelBC;
                    }
                    else
                    {
                        currRow = tunnelAR;
                        currCol = tunnelAC;
                    }
                    mtrx[currRow, currCol] = '.';
                    kilometers += 20;
                }
                else if (mtrx[currRow, currCol] == 'F')
                {

                    mtrx[currRow, currCol] = 'C';
                    Console.WriteLine($"Racing car {carNum} finished the stage!");
                    break;
                }
            }
            Console.WriteLine($"Distance covered {kilometers} km.");

            Print(mtrx);

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

            if (currMove == "right")
            {
                currPositionC++;
            }

            int[] newPosition = new int[2] { currPositionR, currPositionC };

            return newPosition;

        }
        private static bool IsCellValid(int[] newPosition, int mtrxSize)
        {
            int row = newPosition[0];
            int col = newPosition[1];


            if (row >= 0 && row < mtrxSize && col >= 0 && col < mtrxSize)
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
