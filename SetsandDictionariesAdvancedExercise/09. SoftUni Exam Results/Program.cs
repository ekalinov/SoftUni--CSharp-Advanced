using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._SoftUni_Exam_Results
{
    internal class Program
    {
        static void Main(string[] args)
        {


          Dictionary<string, int> participants = new Dictionary<string, int>();

            Dictionary<string, int> submissions = new Dictionary<string, int>();

            //Peter - Java - 84
            //George - C#-70
            //George - C#-84
            //Sam - C#-94
            //exam finished

            while (true)
            {
                string[] inputArg = Console.ReadLine().Split("-", StringSplitOptions.RemoveEmptyEntries);

                if (inputArg[0] == "exam finished") break;

                string participant = inputArg[0];
                string language = inputArg[1];
                if (inputArg[1] == "banned")
                {
                    participants.Remove(participant);
                    continue;
                }

                int points = int.Parse(inputArg[2]);

                if (!participants.ContainsKey(participant))
                {
                    participants.Add(participant, points);
                }
                else
                {
                    if (participants[participant]< points)
                    {
                        participants[participant] = points;
                    }
                }
                

                if (!submissions.ContainsKey(language))
                {
                    submissions.Add(language, 0);
                }
                submissions[language]++;


                //Ex. when someone is banned => "Sam-banned"

            }


            Console.WriteLine("Results:");

            foreach (var kvp in participants.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key} | {kvp.Value}");
            }

            Console.WriteLine("Submissions:");

            foreach (var kvp in submissions.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }


        }
    }
}
