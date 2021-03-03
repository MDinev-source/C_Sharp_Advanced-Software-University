namespace Guild
{
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;
    public class Guild
    {
        private List<Player> players;
        public Guild(string name, int capacity)
        {
            this.players = new List<Player>();
            Name = name;
            Capacity = capacity;
        }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count
        {
            get
            {
                return this.players.Count;
            }
        }

        public void AddPlayer(Player player)
        {
            if (players.Count < Capacity)
            {
                players.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            if (players.Any(x => x.Name == name))
            {
                Player currentPlayer = players.FirstOrDefault(x => x.Name == name);
                players.Remove(currentPlayer);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void PromotePlayer(string name)
        {
            if (players.Find(x => x.Name == name) == null || players.Find(x => x.Name == name).Rank == "Member")
                return;
            else
                players.Find(x => x.Name == name).Rank = "Member";
        }
        public void DemotePlayer(string name)
        {
            if (players.Find(x => x.Name == name) == null || players.Find(x => x.Name == name).Rank == "Trial")
                return;
            else
                players.Find(x => x.Name == name).Rank = "Trial";
        }

        public Player[] KickPlayersByClass(string classPlayers)
        {
            Player[] arr;
            arr = players.Where(x => x.Class == classPlayers).ToArray();
            players = players.Where(x => x.Class != classPlayers).ToList();
            return arr;
        }
        public string Report()
        {
            StringBuilder myString = new StringBuilder();
            myString.AppendLine($"Players in the guild: {this.Name}");
            foreach (var player in this.players)
            {
                myString.AppendLine($"Player {player.Name}: {player.Class}");
                myString.AppendLine($"Rank: {player.Rank}");
                myString.AppendLine($"Description: {player.Description}");
            }
            return myString.ToString().TrimEnd();
        }
    }
}
