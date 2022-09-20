using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int mtrxSize = int.Parse(Console.ReadLine());


            int[][] mtrx = new int[mtrxSize][];


            for (int row = 0; row < mtrx.GetLength(0); row++)
            {
                mtrx[row] = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();


            }


                string[] cmd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (cmd[0] != "END")
            {

                

                int cmdRow = int.Parse(cmd[1]);
                int cmdCow = int.Parse(cmd[2]);
                int cmdValue = int.Parse(cmd[3]);


                if (cmdRow >= 0 && cmdRow < mtrx.GetLength(0) && cmdCow >= 0 && cmdCow < mtrx[cmdRow].Length)
                {
                    if (cmd[0].ToLower() == "add")
                    {

                        mtrx[cmdRow][cmdCow] += cmdValue;
                    }
                    else
                    {
                        mtrx[cmdRow][cmdCow] -= cmdValue;

                    }

                }
                else
                    Console.WriteLine("Invalid coordinates");

                cmd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }



            for (int row = 0; row < mtrx.GetLength(0); row++)
            {

                for (int cow = 0; cow < mtrx[row].Length; cow++)
                {
                    Console.Write(mtrx[row][cow] + " ");
                }
                Console.WriteLine();
            }





        }
    }
}
