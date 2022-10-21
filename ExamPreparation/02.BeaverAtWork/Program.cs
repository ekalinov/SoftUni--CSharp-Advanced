    using System;
    using System.Collections.Generic;
    using System.Linq;

    namespace _0222222.BeaverAtWork
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                int n = int.Parse(Console.ReadLine());


                char[,] mtrx = new char[n, n];

                int branches = 0;
                int currRow = 0;
                int currCol = 0;

                for (int row = 0; row < mtrx.GetLength(0); row++)
                {
                    char[] rowInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                    for (int col = 0; col < mtrx.GetLength(0); col++)
                    {
                        mtrx[row, col] = rowInput[col];
                        if (rowInput[col] == 'B')
                        {
                            currRow = row;
                            currCol = col;

                        }

                        if (char.IsLower(rowInput[col]))
                        {
                            branches++;
                        }


                    }

                }

                List<char> branchesStack = new List<char>();
                while (true)
                {
                    string command = Console.ReadLine();
                    if (branchesStack.Count == branches || command == "end")
                    {
                        break;
                    }

                    int[] newPosition = MoveMethod(command, currRow, currCol);
                    if (IsCellValid(newPosition, n))
                    {
                        mtrx[currRow, currCol] = '-';
                        currRow = newPosition[0];
                        currCol = newPosition[1];

                        if (mtrx[currRow, currCol] == 'F')
                        {
                            mtrx[currRow, currCol] = '-';
                            newPosition = MoveMethod(command, currRow, currCol);

                            if (IsCellValid(newPosition, n))
                            {
                                switch (command)
                                {
                                    case "up":
                                        currRow = 0;
                                        break;
                                    case "down":
                                        currRow = n - 1;
                                        break;
                                    case "left":
                                        currCol = 0;
                                        break;
                                    case "right":
                                        currCol = n - 1;
                                        break;
                                }
                            }
                            else
                            {
                                switch (command)
                                {
                                    case "up":
                                        currRow = n - 1;
                                        break;
                                    case "down":
                                        currRow = 0;
                                        break;
                                    case "left":
                                        currCol = n - 1;
                                        break;
                                    case "right":
                                        currCol = 0;
                                        break;
                                }

                            }

                        }

                        if (char.IsLower(mtrx[currRow, currCol]))
                        {
                            branchesStack.Add(mtrx[currRow, currCol]);
                        }




                        mtrx[currRow, currCol] = 'B';


                    }
                    else
                    {
                        if (branchesStack.Any())
                        {
                            branchesStack.RemoveAt(branchesStack.Count-1);
                            branches--;
                        }

                    }





           
                }

                if (branchesStack.Count == branches)
                {

                Console.WriteLine( $"The Beaver successfully collect {branches} wood branches: {string.Join(", ",branchesStack)}.");
                }
                else
                {
                    Console.WriteLine($"The Beaver failed to collect every wood branch. There are {branches-branchesStack.Count } branches left.");
                }
                Print(mtrx);

            }
            private static int[] MoveMethod(string currMove, int startR, int startC)
            {

                int currPositionR = startR;
                int currPositionC = startC;

                //  up
                if (currMove == "up")
                {
                    currPositionR --;
                }
                // down
                if (currMove == "down")
                {
                    currPositionR ++;
                }
                // left
                if (currMove == "left")
                {
                    currPositionC --;
                }

                if (currMove == "right")
                {
                    currPositionC ++;
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
                        Console.Write(mtrx[row, col] + " ");

                    }
                    Console.WriteLine();

                }


            }

        }
    }

