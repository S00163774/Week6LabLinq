using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExample
{

    public class Player
    {
        Guid _id;
        string _name;
        int _xp;

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Xp { get; set; }

        public override string ToString()
        {
            return Id.ToString() + " " + Name + " " + Xp.ToString();
        }
    }
    class Program
    {
        static List<Player> players = new List<Player>()
        {
            new Player { Id = Guid.NewGuid(), Name = "Joe", Xp = 100 },
            new Player { Id = Guid.NewGuid(), Name = "Peter", Xp = 10 },
            new Player { Id = Guid.NewGuid(), Name = "Mary", Xp = 200 },
            new Player { Id = Guid.NewGuid(), Name = "Michael", Xp = 300 }
        };
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            // Return the first occurance of the match or null

            Player found = players.FirstOrDefault(p => p.Name == "Mary");
            if (found != null)
            {
                Console.WriteLine("{0}", found.ToString());
            }
            else
            {
                Console.WriteLine("Not Found");
            }
            //
            Console.WriteLine(" ");
            // Return all those with an XP value over 100

            List<Player> topPlayers = players.Where(plr => plr.Xp >= 100).ToList();

            if (topPlayers.Count > 0)
            {
                foreach (var item in topPlayers)
                {
                    Console.WriteLine("{0}", item.ToString());
                }
            }
            //
            Console.WriteLine(" ");
            Console.WriteLine("-- Top Scores --");
            //

            var ScoreBoard = players
                                    .OrderByDescending(o => o.Xp)
                                    .Select(scores => new { scores.Name, scores.Xp });

            foreach (var item in ScoreBoard)
            {
                Console.WriteLine("{0} {1}", item.Name, item.Xp);
            }


        }
    }
}
