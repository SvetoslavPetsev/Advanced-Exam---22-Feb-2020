namespace Guild
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Guild
    {
        private List<Player> roster;
        public Guild(string name, int capcity)
        {
            this.Name = name;
            this.Capacity = capcity;
            this.roster = new List<Player>();
        }
        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public int Count
        {
            get
            {
                return this.roster.Count;
            }
        }

        public void AddPlayer(Player player)
        {
            if (this.Capacity > this.roster.Count && !roster.Any(x => x.Name == player.Name))
            {
                this.roster.Add(player);
            }

        }
        public bool RemovePlayer(string name)
        {
            if (this.roster.Any(x => x.Name == name))
            {
                Player selected = this.roster.FirstOrDefault(x => x.Name == name);
                this.roster.Remove(selected);
                return true;
            }
            return false;
        }

        public void PromotePlayer(string name)
        {
            this.roster.FirstOrDefault(x => x.Name == name).Rank = "Member";
        }
        public void DemotePlayer(string name)
        {
            this.roster.FirstOrDefault(x => x.Name == name).Rank = "Trial";
        }
        public Player[] KickPlayersByClass(string @class)
        {
            List<Player> selected = new List<Player>();
            foreach (var player in roster)
            {
                if (player.Class == @class)
                {
                    selected.Add(player);
                }
            }
            this.roster.RemoveAll(x => x.Class == @class);
            return selected.ToArray();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {this.Name}");
            foreach (var player in roster)
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
