using System.Data.Entity;
namespace Highscore
{
    class HighscoreInitializer : DropCreateDatabaseIfModelChanges<HighscoreContext>
    {
        protected override void Seed(HighscoreContext context)
        {
            base.Seed(context);
        }
    }
}
