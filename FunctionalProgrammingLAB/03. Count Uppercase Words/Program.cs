    using System;
    using System.Linq;

    namespace _03._Count_Uppercase_Words
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                Func<string, bool> isCharCapital = s => char.IsUpper(s[0]);

                string[] inputArray = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .Where(isCharCapital)
                        .ToArray();

                Console.WriteLine(string.Join(Environment.NewLine,inputArray));


            }
        }
    }
