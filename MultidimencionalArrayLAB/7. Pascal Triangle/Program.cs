using System;

namespace _7._Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int pascalTriangularRows = int.Parse(Console.ReadLine());


            long[][] mtrx = new long[pascalTriangularRows][] ;

            mtrx[0] = new long[1] {1};


            for (int row = 1; row < mtrx.GetLength(0); row++)
            {

                mtrx[row] = new long[row+1];

                for (int col = 0; col < mtrx[row].Length; col++)
                {
                    if (col == 0|| col== mtrx[row].Length-1)
                    {
                        mtrx[row][col] = 1;
                    }
                    else
                    {
                        mtrx[row][col] = mtrx[row - 1][col - 1] + mtrx[row - 1][col];
                    }

                }

            }

            for (int row = 0; row < pascalTriangularRows; row++)
            {
                Console.WriteLine(String.Join(" ", mtrx[row]));  
            }





        }
    }
}
