using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Predicate_Party_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            Func<List<string>, string[], List<string>> doubleGuests = (guests, cmdArgs) =>
                        {
                            List<string> result = new List<string>();
                            foreach (var guest in guests)
                            {
                                result.Add(guest);
                                if (cmdArgs[1] == "StartsWith")
                                {
                                    if (guest.StartsWith(cmdArgs[2]))
                                    {
                                        result.Add(guest);
                                    }
                                }
                                else if (cmdArgs[1] == "EndsWith")
                                {
                                    if (guest.EndsWith(cmdArgs[2]))
                                    {
                                        result.Add(guest);
                                    }
                                }
                                else if (guest.Length == int.Parse(cmdArgs[2]))
                                {

                                    result.Add(guest);
                                }

                            }

                            return result;
                        };

            Func<List<string>, string[], List<string>> removeGuests = (guests, cmdArgs) =>
            {

                for (int i = 0; i < guests.Count; i++)
                {
                    if (cmdArgs[1] == "StartsWith")
                    {
                        if (guests[i].StartsWith(cmdArgs[2]))
                        {
                            guests.RemoveAll(c =>c.StartsWith(cmdArgs[2]));
                        }
                    }
                    else if (cmdArgs[1] == "EndsWith")
                    {
                        if (guests[i].EndsWith(cmdArgs[2]))
                        {
                            guests.RemoveAll(c => c.EndsWith(cmdArgs[2]));
                        }
                    }
                    else if (guests[i].Length == int.Parse(cmdArgs[2]))
                    {

                        guests.RemoveAll(c => c.Length == int.Parse(cmdArgs[2]));
                    }

                }

                return guests;
            };



            while (true)
            {
                string cmd = Console.ReadLine();
                if (cmd == "Party!")
                {
                    break;
                }
                string[] cmdArg = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch (cmdArg[0])
                {
                    case "Double":
                        names = doubleGuests(names, cmdArg);
                        break;
                    case "Remove":
                        names = removeGuests(names, cmdArg);
                        break;

                }

            }

            if (names.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.Write(string.Join(", ", names));
                Console.WriteLine($" are going to the party!");
            }

        }
    }
}
