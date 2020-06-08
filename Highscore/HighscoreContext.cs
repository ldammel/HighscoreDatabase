using System.Data.Entity;
namespace Highscore
{
    public class HighscoreContext : DbContext
    {
        static HighscoreContext()
        {
            Database.SetInitializer<HighscoreContext>(new HighscoreInitializer());
        }

        public HighscoreContext() : base() { }

        public DbSet<Game> Games { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Score> Scores { get; set; }
    }

}
