using System;
using System.Linq;
using System.Text;

namespace _5._Snake_Moves
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] mtrxSize = Console.ReadLine()
                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse)
                                        .ToArray();
            int rows = mtrxSize[0];
            int cols = mtrxSize[1];

            string snake = Console.ReadLine();

            StringBuilder sb = new StringBuilder();

            while (sb.Length <= rows * cols)
            {
                sb.Append(snake);
            }

            string snakesLenght = sb.ToString();

            int counter = 0;

            string[,] mtrx = new string[rows, cols];

            for (int row = 0; row < mtrx.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int cow = 0; cow < mtrx.GetLength(1); cow++)
                    {
                        mtrx[row, cow] = snakesLenght[counter].ToString();
                        counter++;
                    }
                }
                else
                {
                    for (int cow = mtrx.GetLength(1)-1; cow >= 0 ; cow--)
                    {
                        mtrx[row, cow] = snakesLenght[counter].ToString();
                        counter++;
                    }

                }
            }


            for (int row = 0; row < mtrx.GetLength(0); row++)
            {

                for (int cow = 0; cow < mtrx.GetLength(1); cow++)
                {

                    Console.Write(mtrx[row, cow]);
                }
                Console.WriteLine();
            }


        }
    }
}
