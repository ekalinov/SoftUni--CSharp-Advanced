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
                string student = inputArgs[2];
                int points = int.Parse(inputArgs[3]);


                if (!contestPasswords.ContainsKey(contest) || contestPasswords[contest] != password)
                {
                    continue;
                }


                if (!nameContestPoints.ContainsKey(student))
                {
                    nameContestPoints.Add(student, new Dictionary<string, int>());
                }

                if (!nameContestPoints[student].ContainsKey(contest))
                {
                    nameContestPoints[student].Add(contest, points);
                }

                if (nameContestPoints[student][contest] < points)
                {
                    nameContestPoints[student][contest] = points;
                }

            }


            nameContestPoints = nameContestPoints.OrderBy(x => x.Key)
                                                    .ToDictionary(x => x.Key, x => x.Value);


            string topStudent = string.Empty;
            int maxPoints = int.MinValue;

            foreach (KeyValuePair<string, Dictionary<string, int>> student in nameContestPoints)
            {
                string studentName = student.Key;

                Dictionary<string, int> curcontests = student.Value;

                int pointsOfTheStudent = 0;

                nameContestPoints[studentName] = curcontests.OrderByDescending(y => y.Value).ToDictionary(x => x.Key, x => x.Value);

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

            Print(nameContestPoints);


        }

        private static void Print(Dictionary<string, Dictionary<string, int>> students)
        {
            Console.WriteLine($"Ranking:");

            foreach (var student in students)
            {
                Console.WriteLine($"{student.Key}");
            
                    foreach (var contest in student.Value)
                    {
                        Console.WriteLine($"# {contest.Key} -> {contest.Value}");
                    }
                
            }

        }
    }
}
