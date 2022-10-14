using System;

namespace _02.TheBattleoftheFiveArmies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int armyArmour = int.Parse(Console.ReadLine());

            int n = int.Parse(Console.ReadLine());


            char[][] mtrx = new char[n][];

            int armyCurrR = 0;
            int armyCurrC = 0;
            for (int row = 0; row < mtrx.GetLength(0); row++)
            {
                char[] rowInput = Console.ReadLine().ToCharArray();
                mtrx[row] = new char[rowInput.Length] ;

                for (int cow = 0; cow < rowInput.Length; cow++)
                {
                    mtrx[row][cow] = rowInput[cow];
                    if (mtrx[row][cow] == 'A')
                    {
                        armyCurrR = row;
                        armyCurrC = cow;
                    }
                }
            }

            

            

            mtrx[armyCurrR][armyCurrC] = '-';

            while (true)
            {
                if (armyArmour<=0)
                {
                    break;
                }
                string[] inputArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string direction = inputArgs[0];
                int spawnR = int.Parse(inputArgs[1]);
                int spawnC = int.Parse(inputArgs[2]);

                mtrx[spawnR][spawnC] = 'O';

                int[] lastPosArgs = new int[] { armyCurrR, armyCurrC };

                mtrx[armyCurrR][armyCurrC] = '-';

                int[] newPosArgs = MoveMethod(direction, armyCurrR, armyCurrC);


                armyArmour--;
                armyCurrR = newPosArgs[0];
                armyCurrC = newPosArgs[1];

                if (!IsCellValid(armyCurrR, armyCurrC, mtrx.GetLength(0), mtrx[0].Length))
                {
                   
                    armyCurrR = lastPosArgs[0];
                    armyCurrC = lastPosArgs[1];
                    continue;
                }

                

                if (mtrx[armyCurrR][armyCurrC] == 'M')
                {
                    mtrx[armyCurrR][armyCurrC] = '-';
                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {armyArmour}");
                    break;
                }

                else if (mtrx[armyCurrR][armyCurrC] == 'O')
                {
                    armyArmour -= 2;
                    if (armyArmour <= 0)
                    {
                        mtrx[armyCurrR][armyCurrC] = 'X';
                        Console.WriteLine($"The army was defeated at {armyCurrR};{armyCurrC}.");
                        break;
                    }
                    else
                    {
                        mtrx[armyCurrR][armyCurrC] = '-';

                    }
                }
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

        private static bool IsCellValid(int row, int col, int rows, int cols)
        {
            if (row >= 0 && row < rows && col >= 0 && col < cols)
            {
                return true;
            }
            return false;
        }

        private static void Print(char[][] mtrx)
        {
            for (int row = 0; row < mtrx.GetLength(0); row++)
            {
                for (int col = 0; col < mtrx[row].Length; col++)
                {
                    Console.Write(mtrx[row][col]);

                }
                Console.WriteLine();
            }

        }
    }
}
