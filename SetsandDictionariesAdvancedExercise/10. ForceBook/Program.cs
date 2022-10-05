using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, SortedSet<string>> sideUsersPairs = new Dictionary<string, SortedSet<string>>();

            while (true)
            {

                string inputArgs = Console.ReadLine();

                string user = string.Empty;
                string forceSide = string.Empty;

                if (inputArgs == "Lumpawaroo") break;

                if (inputArgs.Contains(" | "))
                {
                    string[] argsInfo = inputArgs.Split(" | ", StringSplitOptions.RemoveEmptyEntries);

                    user = argsInfo[1];
                    forceSide = argsInfo[0];
                    if (sideUsersPairs.Values.Any(s=>s.Contains(user)))
                    {
                        continue;
                    }


                    if (!sideUsersPairs.ContainsKey(forceSide))
                    {
                        sideUsersPairs.Add(forceSide, new SortedSet<string>());
                    }
                    sideUsersPairs[forceSide].Add(user);

                }
                else
                {
                    string[] argsInfo = inputArgs.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                    user = argsInfo[0];
                    forceSide = argsInfo[1];


                    foreach (var item in sideUsersPairs)
                    {
                        if (item.Value.Contains(user))
                        {
                            if (item.Key != forceSide)
                            {
                                item.Value.Remove(user);
                            }
                        }
                    }

                    if (!sideUsersPairs.ContainsKey(forceSide))
                    {
                        sideUsersPairs.Add(forceSide, new SortedSet<string>());
                       
                    }
                            sideUsersPairs[forceSide].Add(user);
                    Console.WriteLine($"{user} joins the {forceSide} side!");
                }

            }



            var filteredDict = sideUsersPairs.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);


          

            foreach (KeyValuePair<string, SortedSet<string>> kvp in filteredDict)
            {
                if (kvp.Value.Count == 0)
                {
                    continue;
                }
                Console.WriteLine($"Side: {kvp.Key}, Members: {kvp.Value.Count}");
                foreach (var user in kvp.Value)
                {
                    Console.WriteLine($"! {user}");
                }

            }





            // .ToDictionary(x => x.Key.OrderBy(x=>x), x => x.Value).ToDictionary(x => x.Key, x => x.Value);


        }
    }
}
