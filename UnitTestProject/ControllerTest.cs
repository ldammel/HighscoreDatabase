using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Highscore
{
    [TestClass]
    public class ControllerTest
    {
        static Controller ctrl;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext) { ctrl = new Controller(); }

        [TestInitialize]
        public void TestInitialize() {}

        [TestMethod]
        public void CreateUser_NonExistent()
        {
            Assert.IsFalse(ctrl.GetUsers().Any(u => u.Name == "Tester"));
            var user = ctrl.CreateUser("Tester");
            Assert.IsTrue(ctrl.GetUsers().Any(u => u.Name == "Tester"));
        }

        [TestMethod]
        public void GetScoresPerGameTest()
        {
            var game = ctrl.CreateGame("TestGame");
            var user = ctrl.CreateUser("TestUser1");
            var user2 = ctrl.CreateUser("TestUser2");

            int testscore1 = 4856;
            int testscore2 = 1654;

            ctrl.CreateScore(user,game, testscore1);
            ctrl.CreateScore(user2, game, testscore2);

            var totals = ctrl.GetScoresPerGame(game);
            int completeScore = 0;

            foreach (var scores in totals)
            {
                completeScore += scores.Points;
            }
            Assert.AreEqual(testscore1+testscore2, completeScore);
        }
    }
}
