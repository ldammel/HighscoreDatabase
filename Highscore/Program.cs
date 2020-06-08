using System.Data.Entity;
using System;
using System.Linq;
namespace Highscore
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller c = new Controller();
            using (var ctx = new HighscoreContext())
            {

                c.CreateScore(c.CreateUser("Herbert"), c.CreateGame("Fortnite"), 1500);

                c.CreateScore(c.CreateUser("Markus"), c.CreateGame("Fortnite"), 4531);

                c.CreateScore(c.CreateUser("Martin"), c.CreateGame("WoW"), 3200);

                c.CreateScore(c.CreateUser("Mark"), c.CreateGame("Tetris"), 32158);

                c.CreateScore(c.CreateUser("Robert"), c.CreateGame("WoW"), 888654);

                c.CreateScore(c.CreateUser("Lutz"), c.CreateGame("WoW"), 4605);

                foreach (var sc in ctx.Scores.Include("Game").Include("User").Where(s => s.Points > 4600))            
                {                    
                    Console.WriteLine("{1} in Spiel {2}: {0}", sc.Points, sc.User.Name, sc.Game.Name);
                }
            }
        }
    }
}
