using System;
using System.Linq;

namespace _7._Knight_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Input and building the matrix !
            int mtrxSize = int.Parse(Console.ReadLine());

            char[,] mtrx = new char[mtrxSize, mtrxSize];

            for (int row = 0; row < mtrx.GetLength(0); row++)
            {
                string rawInput = Console.ReadLine();

                for (int col = 0; col < mtrx.GetLength(1); col++)
                {
                    mtrx[row, col] = rawInput[col];

                }
            }




            int removedKings = 0;

            int maxKnightsAttacked = 0;
            int maxKnightRow =0;
            int maxKnightCol =0;
                              
               
            while (true)
            {
               
                int knightsUnderAttack = 0;


                for (int row = 0; row < mtrx.GetLength(0); row++)
                {
                    for (int col = 0; col < mtrx.GetLength(1); col++)
                    {
                        if (mtrx[row, col] == 'K')
                        {
                            knightsUnderAttack = AtackedKhights(mtrxSize, row, col, mtrx);
                        }

                        if (maxKnightsAttacked < knightsUnderAttack)
                        {
                            maxKnightsAttacked = knightsUnderAttack;
                            maxKnightRow = row;
                            maxKnightCol = col;
                        }
                    }
                }
                bool isKnightRemoved = false;

                if (maxKnightsAttacked > 0)
                {
                    mtrx[maxKnightRow, maxKnightCol] = '0';

                    maxKnightsAttacked = 0;
                    removedKings++;
                    isKnightRemoved = true;

                }

                if (!isKnightRemoved)
                    break;
            }

            Console.WriteLine(removedKings);

        }


        static int AtackedKhights(int size, int row, int col, char[,] mtrx)
        {
            int kingsAttacked = 0;
            //top Left
            if (isCellValid(size, row - 2, col - 1))
            {
                if (mtrx[row - 2, col - 1] == 'K')
                    kingsAttacked++;
            }
            // Top right
            if (isCellValid(size, row - 2, col + 1))
            {
                if (mtrx[row - 2, col + 1] == 'K')
                    kingsAttacked++;
            }
            // left Up
            if (isCellValid(size, row - 1, col - 2))
            {
                if (mtrx[row - 1, col - 2] == 'K')
                    kingsAttacked++;
            }
            // Right Up
            if (isCellValid(size, row - 1, col + 2))
            {
                if (mtrx[row - 1, col + 2] == 'K')
                    kingsAttacked++;
            }
            // left Down
            if (isCellValid(size, row + 1, col - 2))
            {
                if (mtrx[row + 1, col - 2] == 'K')
                    kingsAttacked++;
            }
            // Right Down
            if (isCellValid(size, row + 1, col + 2))
            {
                if (mtrx[row + 1, col + 2] == 'K')
                    kingsAttacked++;
            }
            //bottom Left
            if (isCellValid(size, row + 2, col - 1))
            {
                if (mtrx[row + 2, col - 1] == 'K')
                    kingsAttacked++;
            }
            // Bottom right
            if (isCellValid(size, row + 2, col + 1))
            {
                if (mtrx[row + 2, col + 1] == 'K')
                    kingsAttacked++;
            }

            return kingsAttacked;

        }

        static bool isCellValid(int size, int row, int col)
        {
            if (row >= 0 && row < size && col >= 0 && col < size)
            {
                return true;
            }



            return false;
        }
    }





}


