using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._The_Party_Reservation_Filter_Module
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            Dictionary<string, Predicate<string>> predicates = new Dictionary<string, Predicate<string>>();
            while (true)
            {
                string cmd = Console.ReadLine();
                if (cmd == "Print")
                {
                    break;
                }
                string[] cmdArg = cmd.Split(";", StringSplitOptions.RemoveEmptyEntries);

                string command = cmdArg[0];
                string filter = cmdArg[1];
                string value = cmdArg[2];

                switch (cmdArg[0])
                {
                    case "Add filter":
                        predicates.Add(filter+value, GetPredicate(filter,value));
                        break;
                    case "Remove filter":
                        predicates.Remove(filter + value);
                        break;
                }

            }


            foreach (var predicate in predicates)
            {

                names.RemoveAll(predicate.Value);

            }

                Console.Write(string.Join(" ", names));
                
            
        }

        private static Predicate<string> GetPredicate(string filter, string value)
        {
            switch (filter)
            {
                case "Starts with":
                    return s => s.StartsWith(value);
                case "Ends with":
                    return s => s.EndsWith(value);
                case "Contains":
                    return s => s.Contains(value);
                case "Length":
                    return s => s.Length == int.Parse(value);
            }
            return null;
        }
    }
}
