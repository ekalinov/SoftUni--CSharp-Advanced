using System;
using System.Linq;

namespace _02.WallDestroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] wall = new char[n, n];

            for (int row = 0; row < wall.GetLength(0); row++)
            {
                char[] rowInput = Console.ReadLine().ToCharArray();


                for (int cow = 0; cow < wall.GetLength(1); cow++)
                {
                    wall[row, cow] = rowInput[cow];

                }
            }

            //Finding starting position of the player
            int startingPosRow = 0;
            int startingPosCol = 0;

            for (int row = 0; row < wall.GetLength(0); row++)
            {
                for (int col = 0; col < wall.GetLength(1); col++)
                {
                    if (wall[row, col] == 'V')
                    {
                        startingPosRow = row;
                        startingPosCol = col;
                    }

                }
            }

            //We move until we leave the field or a bunnie kills us 
            int currPositionRow = startingPosRow;
            int currPositionCol = startingPosCol;
            bool isElectrified = false;
            int rodsCounter = 0;

            while (true)
            {
                string direction = Console.ReadLine();
                if (direction == "End")
                {
                    wall[currPositionRow, currPositionCol] = 'V';
                    break;
                }

                wall[currPositionRow, currPositionCol] = '*';

                int[] lastPosition = new int[] { currPositionRow, currPositionCol };

                int[] newPosition = MoveMethod(direction, currPositionRow, currPositionCol, wall);


                currPositionRow = newPosition[0];
                currPositionCol = newPosition[1];

                if (IsCellValid(currPositionRow, currPositionCol, wall.GetLength(0), wall.GetLength(1)))
                {
                    if (wall[currPositionRow, currPositionCol] == '-')
                    {
                        wall[currPositionRow, currPositionCol] = '*';
                    }
                    else if (wall[currPositionRow, currPositionCol] == 'R')
                    {
                        rodsCounter++;
                        currPositionRow = lastPosition[0];
                        currPositionCol = lastPosition[1];

                        Console.WriteLine("Vanko hit a rod!");
                        continue;
                    }
                    else if (wall[currPositionRow, currPositionCol] == '*')
                    {
                        Console.WriteLine($"The wall is already destroyed at position [{currPositionRow}, {currPositionCol}]!");
                    }
                    else if (wall[currPositionRow, currPositionCol] == 'C')
                    {
                        wall[currPositionRow, currPositionCol] = 'E';
                        isElectrified = true;
                        break;
                    }
                }
                else
                {
                    currPositionRow = lastPosition[0];
                    currPositionCol = lastPosition[1];
                }

            }

            int holes = 0;

            for (int row = 0; row < wall.GetLength(0); row++)
            {
                for (int col = 0; col < wall.GetLength(1); col++)
                {
                    if (wall[row, col] == '*' 
                        || wall[row, col] == 'E'
                        || wall[row, col] == 'V')
                    {
                        holes++;
                    }

                }
            }


            if (isElectrified)
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holes} hole(s).");
            }
            else
            {
                Console.WriteLine($"Vanko managed to make {holes} hole(s) and he hit only {rodsCounter} rod(s).");
            }


            Print(wall);

        }

        private static int[] MoveMethod(string currMove, int startR, int startC, char[,] mtrx)
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
