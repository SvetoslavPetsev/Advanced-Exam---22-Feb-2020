namespace Guild
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            Guild guild = new Guild("Weekend Raiders", 20);
            Console.WriteLine(guild.Count);
            Player player = new Player("Mark", "Rogue");
            Console.WriteLine(player);

            guild.AddPlayer(player);
            Console.WriteLine(guild.Count);
            Console.WriteLine(guild.RemovePlayer("Gosho"));

            Player firstPlayer = new Player("Pep", "Warrior");
            Player secondPlayer = new Player("Lizzy", "Priest");
            Player thirdPlayer = new Player("Mike", "Rogue");
            Player fourthPlayer = new Player("Marlin", "Mage");


            secondPlayer.Description = "Best healer EU";
            guild.AddPlayer(firstPlayer);
            guild.AddPlayer(secondPlayer);
            guild.AddPlayer(thirdPlayer);
            guild.AddPlayer(fourthPlayer);

            guild.PromotePlayer("Lizzy");
            Console.WriteLine(guild.RemovePlayer("Pep"));
            
            Player[] kickedPlayers = guild.KickPlayersByClass("Rogue");
            Console.WriteLine(string.Join(", ", kickedPlayers.Select(p => p.Name)));
            Console.WriteLine(guild.Report());
        }
    }
}
