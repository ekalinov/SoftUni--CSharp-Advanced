using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, String> contestPasswords = new Dictionary<string, String>();

            Dictionary<string, Dictionary<string, int>> nameContestPoints = new Dictionary<string, Dictionary<string, int>>();

            // Reading Contest-Password Pairs 

            while (true)
            {
                string inputConest = Console.ReadLine();
                if (inputConest == "end of contests")
                {
                    break;
                }

                string[] contPassArr = inputConest.Split(":");

                if (!contestPasswords.ContainsKey(contPassArr[0]))
                {
                    contestPasswords.Add(contPassArr[0], contPassArr[1]);
                }

            }

            // Adding candidates with their contest and points

            while (true)
            {
                string inputConest = Console.ReadLine();
                if (inputConest == "end of submissions")
                {
                    break;
                }

                string[] inputArgs = inputConest.Split("=>");

                string contest = inputArgs[0];
                string password = inputArgs[1];
                string candidate = inputArgs[2];
                int points = int.Parse(inputArgs[3]);

                // Checking is given password matches the password of the contest
                if (!contestPasswords.ContainsKey(contest) || contestPasswords[contest] != password)
                {
                    continue;
                }
                
                //Check if candidate exist and adds it if not
                if (!nameContestPoints.ContainsKey(candidate))
                {
                    nameContestPoints.Add(candidate, new Dictionary<string, int>());
                }
                
                // Check if the candidate participate the given contest and adds contest if not
                if (!nameContestPoints[candidate].ContainsKey(contest))
                {
                    nameContestPoints[candidate].Add(contest, points);
                }
                //Check if the points given are greater than existing points and change if they are! 
                if (nameContestPoints[candidate][contest] < points)
                {
                    nameContestPoints[candidate][contest] = points;
                }

            }

            //Sorting the dictionary first by name of the candidate => .OrderBy(x => x.Key)
            // Then ordering values of the nested Dictionary by descending => .ToDictionary(x => x.Key, x => x.Value.OrderByDescending(y => y.Value)

            nameContestPoints = nameContestPoints.OrderBy(x => x.Key)
                                                .ToDictionary(x => x.Key, x => x.Value.OrderByDescending(y => y.Value)
                                                .ToDictionary(y => y.Key, y => y.Value));

            

            PrintingBestCandidate(nameContestPoints);


            Print(nameContestPoints);

        }

        //Finds and print the best candidate and its points
        private static void PrintingBestCandidate(Dictionary<string, Dictionary<string, int>> nameContestPoints)
        {

            string topStudent = string.Empty;
            int maxPoints = int.MinValue;

            foreach (KeyValuePair<string, Dictionary<string, int>> student in nameContestPoints)
            {
                string studentName = student.Key;

                Dictionary<string, int> curcontests = student.Value;

                int pointsOfTheStudent = 0;

                foreach (var contest in curcontests)
                {

                    pointsOfTheStudent += contest.Value;

                }
                if (pointsOfTheStudent > maxPoints)
                {
                    maxPoints = pointsOfTheStudent;
                    topStudent = studentName;
                }

            }


            Console.WriteLine($"Best candidate is {topStudent} with total {maxPoints} points.");
        }

        private static void Print(Dictionary<string, Dictionary<string, int>> students)
        {
            Console.WriteLine($"Ranking:");

            foreach (var student in students)
            {
                Console.WriteLine($"{student.Key}");
            
                    foreach (var contest in student.Value)
                    {
                        Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                    }
                
            }

        }
    }
}
