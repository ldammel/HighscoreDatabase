using System.Collections.Generic;
namespace Highscore
{
    public class Score
    {
        public int ID { get; set; }
        public int Points { get; set; }

        public int GameId { get; set; }
        public virtual Game Game { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
