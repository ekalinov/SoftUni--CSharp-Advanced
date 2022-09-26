using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._The_V_Logger
{
    internal class Program
    {
        class Vlogger
        {
            public Vlogger(string name)
            {
                Name = name;
                this.followers = new SortedSet<string>();
                this.following = 0;
            }

            public string Name { get; set; }
            public SortedSet<string> followers { get; set; }
            public int following { get; set; }

        }




        static void Main(string[] args)
        {
            List<Vlogger> vlogers = new List<Vlogger>();

            while (true)
            {
                string[] inputTokens = Console.ReadLine().Split(' ');
                string cmd = inputTokens[0];
                if (cmd == "Statistics")
                {
                    break;
                }

                string action = inputTokens[1];

                if (action == "joined")
                {
                    JoiningVlog(inputTokens, vlogers);
                }
                else
                {
                    AddingFollowers(inputTokens, vlogers);
                }

            }



            vlogers = vlogers.OrderByDescending(x => x.followers.Count).ThenBy(x => x.following).ToList(); ;


            Print(vlogers);


        }


        private static void JoiningVlog(string[] inputTokens, List<Vlogger> vlogers)
        {

            string vloggerName = inputTokens[0];

            if (!vlogers.Any(x => x.Name == vloggerName))
            {
                vlogers.Add(new Vlogger(vloggerName));
            }

        }

        private static void AddingFollowers(string[] inputTokens, List<Vlogger> vlogers)
        {
            string user1 = inputTokens[0];
            string user2 = inputTokens[2];

            if (vlogers.Any(x => x.Name == user1)
                && vlogers.Any(x => x.Name == user2))
            {

                Vlogger vlogerFollowing = vlogers.Single(x => x.Name == user1);
                Vlogger vlogerToFollow = vlogers.Single(x => x.Name == user2);





                if (user1 != user2
                    && !vlogerToFollow.followers.Contains(vlogerFollowing.Name))

                {

                    // User 1 became follower to User 2 

                    vlogerToFollow.followers.Add(user1);


                    // User 1 increase his following 

                    vlogerFollowing.following++;

                }
            }



        }

        private static void Print(List<Vlogger> vlogers)
        {
            Console.WriteLine($"The V-Logger has a total of {vlogers.Count} vloggers in its logs.");

            for (int i = 0; i < vlogers.Count; i++)
            {
                Vlogger v = vlogers[i];

                Console.WriteLine($"{i + 1}. {v.Name} : {v.followers.Count} followers, {v.following} following");

                if (i == 0)
                {
                    foreach (var follower in v.followers)
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }

            }

        }
    }
}
