using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Highscore
{
    public class Controller
    {
        public int CreateUser(string name)
        {
            using (var ctx = new HighscoreContext())
            {
                var user = new User() { Name = name };
                var x = ctx.Users.Add(user);
                ctx.SaveChanges();
                return x.ID;
            }                
        }

        public int CreateGame(string name)
        {
            using (var ctx = new HighscoreContext())
            {
                var game = new Game() { Name = name };
                var x = ctx.Games.Add(game);
                ctx.SaveChanges();
                return x.ID;
            }
        }

        public void CreateScore(int userId, int gameId, int points)
        {
            using (var ctx = new HighscoreContext())
            {
                User user = null;
                foreach (var u in ctx.Users.Where(s => s.ID == userId))
                {
                    user = u;
                }
                Game game = null;
                foreach (var g in ctx.Games.Where(s => s.ID == gameId))
                {
                    game = g;
                }
                var score = new Score() { User = user, Game = game, Points = points };
                var x = ctx.Scores.Add(score);
                ctx.SaveChanges();
            }
        }

        public IEnumerable<GameWithHighscore> GetGames()        {            using (var ctx = new HighscoreContext())            {                return ctx.Scores                    .GroupBy(s => s.Game)                    .Select(g => new GameWithHighscore(){ Game = g.Key, HighScore = g.OrderByDescending(s => s.Points).First().Points})                    .ToList();
            }        }

        public IEnumerable<User> GetUsers()
        {            
            using (var ctx = new HighscoreContext())
            {
                List<User> users = new List<User>();
                foreach (var u in ctx.Users)
                {
                    users.Add(u);
                }
                return users;
            }
        }

        public IEnumerable<Score> GetScoresPerGame(int gameId)
        {
            using (var ctx = new HighscoreContext())
            {
                return ctx.Scores.Where(s => s.GameId == gameId).OrderByDescending(s => s.Points).Take(10).ToList();
            }            
        }

        public IEnumerable<Game> GetGamesPerUser(int userId)
        {            
            using (var ctx = new HighscoreContext())
            {
                return ctx.Scores.Where(s => s.UserId == userId).Select(g => g.Game).Distinct().ToList();
            }            
        }

        public IEnumerable<UserWithScore> GetTotalScores()
        {
            using (var ctx = new HighscoreContext())
            {
                return ctx.Scores.GroupBy(u => u.User).Select(g => new UserWithScore(){ ID = g.Key.ID,Name = g.Key.Name, Score = g.Sum(s => s.Points)})
                .OrderByDescending(o => o.Score)
                .Take(10)
                .ToList();
            }
        }
    }
}
