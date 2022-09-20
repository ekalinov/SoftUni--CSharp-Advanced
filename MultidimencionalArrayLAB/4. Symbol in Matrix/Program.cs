using System;
using System.Linq;

namespace _4._Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int mtrxSize = int.Parse(Console.ReadLine());


            char[,] mtrx = new char[mtrxSize, mtrxSize];


            for (int row = 0; row < mtrx.GetLength(0); row++)
            {
                string rawInput = Console.ReadLine();


                for (int cow = 0; cow < mtrx.GetLength(1); cow++)
                {
                    mtrx[row, cow] = (char)rawInput[cow];
                }
            }

            char searchedChar = char.Parse(Console.ReadLine());


            int searchedCharRow = 0;
            int searchedCharCol = 0;

            bool isCharFound = false;



            for (int row = 0; row < mtrx.GetLength(0); row++)
            {

                for (int cow = 0; cow < mtrx.GetLength(1); cow++)
                {
                    if (mtrx[row, cow] == searchedChar)
                    {
                        isCharFound = true;
                        searchedCharRow = row;  
                        searchedCharCol = cow;
                        break;

                    }

                }
                if (isCharFound)
                    break;
            }

            if (isCharFound)
                Console.WriteLine($"({searchedCharRow}, {searchedCharCol})");
            else
                Console.WriteLine($"{searchedChar} does not occur in the matrix");
        }
    }
}
