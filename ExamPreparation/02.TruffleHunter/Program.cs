using System;
using System.Linq;

namespace _022222.TruffleHunter
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());


            char[,] mtrx = new char[n, n];


            for (int row = 0; row < mtrx.GetLength(0); row++)
            {
                char[] rowInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int cow = 0; cow < mtrx.GetLength(0); cow++)
                {
                    mtrx[row, cow] = rowInput[cow];
                }

            }

            int summerTruffels = 0;
            int blackTruffels = 0;
            int whiteTruffels = 0;
            int wildBoarTruffels = 0;


            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Stop the hunt")
                {
                    break;
                }

                string[] cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string cmd = cmdArgs[0];
                int row = int.Parse(cmdArgs[1]);
                int col = int.Parse(cmdArgs[2]);

                switch (cmd)
                {
                    case "Collect":
                        if (IsCellValid(row, col, n))
                        {
                            switch (mtrx[row, col])
                            {
                                case 'S':
                                    summerTruffels++;
                                    break;
                                case 'W':
                                    whiteTruffels++;
                                    break;
                                case 'B':
                                    blackTruffels++;
                                    break;
                            }
                            mtrx[row, col] = '-';
                        }
                        break;
                    case "Wild_Boar":
                        string direction = cmdArgs[3];

                        while (IsCellValid(row, col, n))
                        {

                            if (mtrx[row, col] == 'S' || mtrx[row, col] == 'W' || mtrx[row, col] == 'B')
                            {
                                wildBoarTruffels++;
                            }
                            mtrx[row, col] = '-';
                            int[] newPosition = MoveMethod(direction, row, col);

                            row = newPosition[0];
                            col = newPosition[1];
                        }
                        break;
                }

            }


            Console.WriteLine($"Peter manages to harvest {blackTruffels} black, {summerTruffels} summer, and {whiteTruffels} white truffles.");
            Console.WriteLine($"The wild boar has eaten {wildBoarTruffels} truffles.");
            Print(mtrx);


        }



        private static int[] MoveMethod(string currMove, int startR, int startC)
        {

            int currPositionR = startR;
            int currPositionC = startC;

            //  up
            if (currMove == "up")
            {
                currPositionR-=2;
            }
            // down
            if (currMove == "down")
            {
                currPositionR += 2;
            }
            // left
            if (currMove == "left")
            {
                currPositionC -= 2;
            }
            // right
            if (currMove == "right")
            {
                currPositionC += 2;
            }

            int[] newPosition = new int[2] { currPositionR, currPositionC };

            return newPosition;
        }

        private static bool IsCellValid(int row, int col, int mtrxSize)
        {

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
