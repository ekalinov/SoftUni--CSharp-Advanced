using System;
using System.Linq;

namespace _02.Armory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());


            char[,] mtrx = new char[n, n];

            bool isThereMirrors= false;
            int currRow = 0;
            int currCol = 0;

            int mirrorAR = 0;
            int mirrorAC = 0;

            int mirrorBR = 0;
            int mirrorBC = 0;


            for (int row = 0; row < mtrx.GetLength(0); row++)
            {
                char[] rowInput = Console.ReadLine().ToCharArray();
                for (int col = 0; col < mtrx.GetLength(0); col++)
                {
                    mtrx[row, col] = rowInput[col];
                    if (rowInput[col] == 'A')
                    {
                        currRow = row;
                        currCol = col;

                    }
                    if (rowInput[col] == 'M')
                    {
                        if (isThereMirrors)
                        {
                            mirrorBR = row;
                            mirrorBC = col;
                            continue;
                        }
                        isThereMirrors = true;
                        mirrorAR = row;
                        mirrorAC = col;
                    }


                }

            }
            int swordsCollecter = 0;
            while (true)
            {

                if (swordsCollecter>=65)
                {
                    Console.WriteLine("Very nice swords, I will come back for more!");
                    break;
                }
                string command = Console.ReadLine();

                int[] newPosition = MoveMethod(command, currRow, currCol);

                if (!IsCellValid(newPosition,n))
                {
                    mtrx[currRow, currCol] = '-';
                    Console.WriteLine("I do not need more swords!");
                    break;
                }


                mtrx[currRow, currCol] = '-';
                currRow = newPosition[0];
                currCol = newPosition[1];

                if (char.IsDigit(mtrx[currRow, currCol]))
                {
                    swordsCollecter += int.Parse(mtrx[currRow, currCol].ToString());
                    mtrx[currRow, currCol] = '-';
                }
                else if (mtrx[currRow, currCol]=='M')
                {
                    if (currRow== mirrorAR && currCol== mirrorAC)
                    {
                        mtrx[currRow, currCol] = '-';
                        currRow = mirrorBR;
                        currCol = mirrorBC;
                    }
                    else
                    {
                        mtrx[currRow, currCol] = '-';
                        currRow = mirrorAR;
                        currCol = mirrorAC;
                    }

                }


                mtrx[currRow, currCol] = 'A';
                

            }
            Console.WriteLine($"The king paid {swordsCollecter} gold coins.");
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
