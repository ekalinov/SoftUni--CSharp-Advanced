using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basketball
{
    public class Team
    {
        //•	Name: string
        //•	OpenPositions: int
        //•	Group: char
        private List<Player> players;

        private string name;

        private int openPositions;

        private char group;


        public Team(string name, int openPositions, char group)
        {
            this.name = name;
            this.openPositions = openPositions;
            this.group = group;
            players = new List<Player>();

        }


        public int Count { get { return players.Count; } }

        public List<Player> Players
        {
            get { return players; }
            set { players = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int OpenPositions
        {
            get { return openPositions; }
            set { openPositions = value; }
        }

        public char Group
        {
            get { return group; }
            set { group = value; }
        }



        // •	Getter Count - returns the count of the players in the team.


        //•	string AddPlayer(Player player) – adds a player to the team's collection, if there are open positions. Before adding a player, check:
        //o If the name or position is null or empty, return "Invalid player's information.".
        //o If there are no more open positions, return "There are no more open positions.". 
        //o If the rating is under 80, return "Invalid player's rating.".
        //o Otherwise, return: "Successfully added {playerName} to the team. Remaining open positions: {openPositions}." and decrease the OpenPositions property of the team.

        public string AddPlayer(Player player)
        {
            if (string.IsNullOrEmpty(player.Name))
            {
                return "Invalid player's information.";
            }
            if (OpenPositions == 0)
            {
                return "There are no more open positions.";
            }
            if (player.Rating < 80)
            {
                return "Invalid player's rating.";
            }

            players.Add(player);
            openPositions--;
            return $"Successfully added {player.Name} to the team. Remaining open positions: {openPositions}.";
        }


        //•	bool RemovePlayer(string name) – removes a player by given name.
        //o If such exists, returns true;
        //        o Otherwise, returns false.
        //Note: Remember to update the OpenPositions property!
        public bool RemovePlayer(string name)
        {
            var player = this.Players.FirstOrDefault(x => x.Name == name);
            if (player != default)
            {
                players.Remove(player);
                openPositions++;
                return true;
            }
            return false;
        }

        //•	int RemovePlayerByPosition(string position) – removes all players by the given position.
        //o If such exist(s), returns the count of the removed players;
        //o Otherwise, returns 0.
        //Note: Remember to update the OpenPositions property!
        public int RemovePlayerByPosition(string position)
        {
            int removedPlayesr = players.RemoveAll(x => x.Position == position);

            openPositions += removedPlayesr;

            return removedPlayesr;

        }

        //•	Player RetirePlayer(string name) method – retire(set his Retired property to true,
        //without removing him from the collection) the player with the given name,
        //if he exists.As a result, return the player, or null, if he don't exist.
        public Player RetirePlayer(string name)
        {
            var player = this.Players.FirstOrDefault(x => x.Name == name);

            if (player != default)
            {
                player.Retired = true;

                return player;
            }
            else
            {
                return null;
            }

        }

        //•	List<Player> AwardPlayers (int games) method – return a list with all players that
        //have participated in games games or more.
        public List<Player> AwardPlayers(int games)
        {
            var awardedPlrs = players.Where(x => x.Games >= games).ToList();
            return awardedPlrs;
        }


        //•	Report() – returns a string with information about the team and players who are not retired in the following format:	
        //"Active players competing for Team {team} from Group {group}:
        //{ Player1}
        //{Player2}
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Active players competing for Team {Name} from Group {Group}:");

            foreach (var player in players.Where(x => x.Retired == false))
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().Trim();
        }











    }
}
