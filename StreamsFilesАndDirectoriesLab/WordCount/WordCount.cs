namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class WordCount
    {
        private static object regex;

        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            StreamReader words = new StreamReader(wordsFilePath);
            StreamReader reader = new StreamReader(textFilePath);
            StreamWriter writer = new StreamWriter(outputFilePath);

            Dictionary<string, int> wordCounts = new Dictionary<string, int>();


            using (reader)
            {

                string pattern = @"\w+";

                string word = words.ReadLine();
                MatchCollection wordsToCount = Regex.Matches(word, pattern);

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();


                    MatchCollection wordsInText = Regex.Matches(line, pattern);

                    foreach (Match item in wordsToCount)
                    {
                        if (!wordCounts.ContainsKey(item.ToString().ToLower()))
                        {
                            wordCounts.Add(item.ToString().ToLower(), 0);
                        }
                    }

                    foreach (Match item in wordsInText)
                    {
                        if (wordCounts.ContainsKey(item.ToString().ToLower()))
                        {
                            wordCounts[item.ToString().ToLower()]++;
                        }
                    }

                }

                var ordered = wordCounts.OrderByDescending(x => x.Value);


                using (writer)
                {
                    foreach (var item in ordered)
                    {
                        writer.WriteLine($"{item.Key} - {item.Value}");
                    }

                }
            }




        }
    }
}
