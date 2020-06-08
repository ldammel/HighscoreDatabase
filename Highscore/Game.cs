using System.Collections.Generic;
namespace Highscore
{
    public class Game
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Score> Scores { get; set; }
    }
}
