using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            this.roster = new List<Player>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => roster.Count;

        public void AddPlayer(Player player)
        {
            if (Capacity > Count)
            {
                roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            return roster.RemoveAll(x=>x.Name == name) > 0;
        }

        public void PromotePlayer(string name)
        {
            roster.First(x=>x.Name == name).Rank = "Member";
        }

        public void DemotePlayer(string name)
        {
            roster.First(x => x.Name == name).Rank = "Trial";
        }

        public Player[] KickPlayersByClass(string @class)
        {
            var kickedPlayers = roster.Where(x => x.Class == @class).ToArray();
            roster.RemoveAll( x=> x.Class == @class);
            return kickedPlayers;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: {Name}");
            foreach (var player in roster)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
