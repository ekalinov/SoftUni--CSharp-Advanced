using System;
using System.Linq;

namespace _4._Matrix_Shuffling
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


            string[,] mtrx = new string[rows, cols];

            for (int row = 0; row < mtrx.GetLength(0); row++)
            {
                string[] rawInput = Console.ReadLine()
                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                        .ToArray();

                for (int cow = 0; cow < mtrx.GetLength(1); cow++)
                {
                    mtrx[row, cow] = rawInput[cow];
                }
            }



            string[] cmdArgs = Console.ReadLine()
                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                        .ToArray();


            string cmd = cmdArgs[0].ToLower();
            int oldRow = 0;
            int oldCol = 0;

            int newRow = 0;
            int newCol = 0;


            while (cmd != "end")
            {
                if (cmd == "swap" && cmdArgs.Length == 5)
                {
                    oldRow = int.Parse(cmdArgs[1]);
                    oldCol = int.Parse(cmdArgs[2]);

                    newRow = int.Parse(cmdArgs[3]);
                    newCol = int.Parse(cmdArgs[4]);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                    cmdArgs = Console.ReadLine()
                                     .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                     .ToArray();
                    cmd = cmdArgs[0].ToLower();
                    continue;

                }


                if (cmd == "swap" &&
                        oldRow >= 0 && oldRow < mtrx.GetLength(0) &&
                        oldCol >= 0 && oldCol < mtrx.GetLength(1) &&
                        newRow >= 0 && newRow < mtrx.GetLength(0) &&
                        newCol >= 0 && newCol < mtrx.GetLength(1))
                {
                    string elementOne = mtrx[oldRow, oldCol];
                    string elementTwo = mtrx[newRow, newCol];

                    mtrx[newRow, newCol] = elementOne;
                    mtrx[oldRow, oldCol] = elementTwo;
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                    cmdArgs = Console.ReadLine()
                                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                            .ToArray();
                    continue;

                }

                for (int row = 0; row < mtrx.GetLength(0); row++)
                {

                    for (int cow = 0; cow < mtrx.GetLength(1); cow++)
                    {

                        Console.Write(mtrx[row, cow] + " ");
                    }
                    Console.WriteLine();
                }

                cmdArgs = Console.ReadLine()
                                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                 .ToArray();
                cmd = cmdArgs[0].ToLower();

            }
            
        }
    }
}
