using System;

namespace _02222.Help_A_Mole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());


            char[,] mtrx = new char[n, n];

            int moleCurrR = 0;
            int moleCurrC = 0;
            int teleportAR = 0;
            int teleportAC = 0;
            int teleportBR = 0;
            int teleportBC = 0;
            bool isSecondTeleport = false;

            for (int row = 0; row < mtrx.GetLength(0); row++)
            {
                char[] rowInput = Console.ReadLine().ToCharArray();

                for (int cow = 0; cow < mtrx.GetLength(0); cow++)
                {
                    mtrx[row, cow] = rowInput[cow];

                    if (mtrx[row, cow] == 'M')
                    {
                        moleCurrR = row;
                        moleCurrC = cow;
                    }
                    if (mtrx[row, cow] == 'S')
                    {
                        if (!isSecondTeleport)
                        {

                            isSecondTeleport = true;
                            teleportAR = row;
                            teleportAC = cow;
                        }
                        else
                        {
                            teleportBR = row;
                            teleportBC = cow;
                        }
                    }
                }

            }

            int molePoints = 0;
            while (true)
            {
                string input = Console.ReadLine().ToLower();

                if (molePoints >= 25)
                {
                    Console.WriteLine("Yay! The Mole survived another game!");
                    Console.WriteLine($"The Mole managed to survive with a total of { molePoints} points.");
                    break;
                }
                else if (input == "end")
                {
                    Console.WriteLine("Too bad! The Mole lost this battle!");
                    Console.WriteLine($"The Mole lost the game with a total of {molePoints} points.");
                    break;
                }

                int[] newPosition = MoveMethod(input, moleCurrR, moleCurrC);

                if (IsCellValid(newPosition, n))
                {

                    mtrx[moleCurrR, moleCurrC] = '-';
                    moleCurrR = newPosition[0];
                    moleCurrC = newPosition[1];

                    if (char.IsDigit(mtrx[moleCurrR, moleCurrC]))
                    {
                        int points = int.Parse(mtrx[moleCurrR, moleCurrC].ToString());
                        molePoints += points;

                    }
                    else if (mtrx[moleCurrR, moleCurrC] == 'S')
                    {
                        mtrx[moleCurrR, moleCurrC] = '-';
                        molePoints -= 3;
                        if (moleCurrR == teleportAR && moleCurrC == teleportAC)
                        {
                            moleCurrR = teleportBR;
                            moleCurrC = teleportBC;
                        }
                        else
                        {
                            moleCurrR = teleportAR;
                            moleCurrC = teleportAC;
                        }
                    }

                }
                else
                {
                    Console.WriteLine("Don't try to escape the playing field!");
                    continue;
                }

                mtrx[moleCurrR, moleCurrC] = 'M';


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
