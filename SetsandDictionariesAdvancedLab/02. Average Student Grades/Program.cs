using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] inputNums = Console.ReadLine()
                            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string studentName = inputNums[0];
                decimal studentGrade = decimal.Parse(inputNums[1]);

                if (!students.ContainsKey(studentName))
                {
                    students.Add(studentName, new List<decimal>());
                }

                students[studentName].Add(studentGrade);
            }


            foreach (KeyValuePair<string, List<decimal>> student in students)
            {
                decimal averageGrade = student.Value.Average();

                Console.Write($"{student.Key} -> ");

                foreach (decimal grade in student.Value)
                {
                    Console.Write($"{grade:f2} ");

                }

                Console.WriteLine($"(avg: {averageGrade:f2})");    
            }

        }
    }
}
