namespace LineNumbers
{
    using System;
    using System.IO;

    public class LineNumbers
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            StreamReader reader = new StreamReader(inputFilePath);
            StreamWriter writer = new StreamWriter(outputFilePath);


            using (reader)
            {
                using (writer)
                {
                    string line = reader.ReadLine();
                    int count = 1;
                    while (line != null)
                    {
                        writer.WriteLine($"{count}. {line}");
                    
                        line = reader.ReadLine();
                        count++;
                    }


                }
            }














        }
    }
}
