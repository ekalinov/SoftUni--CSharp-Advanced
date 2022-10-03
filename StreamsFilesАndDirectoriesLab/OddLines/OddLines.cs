namespace OddLines
{
    using System;
    using System.IO;

    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            StreamReader reader = new StreamReader(inputFilePath);
            StreamWriter writer = new StreamWriter(outputFilePath);


            using (reader)
            {
                using (writer)
                {
                    string line = reader.ReadLine();
                    int count = 0;
                    while (line != null)
                    {
                        Console.WriteLine(line);
                        if (count % 2 == 1)
                        {
                            writer.WriteLine(line);

                        }
                        line = reader.ReadLine();
                        count++;
                    }


                }
            }
        }
    }
}
