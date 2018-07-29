using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace KataBowlingGame.Tests
{
    [TestClass]
    public class BowlingGameTests
    {
        #region fields
        private BowlingGame _game;
        #endregion fields

        #region TestMethods
        [TestInitialize]
        public void Initialize()
        {
            _game = new BowlingGame();
        }

        [TestMethod]
        public void TestHitNoPinsForAllThrows()
        {
            //game with 20 throws of 0 falled pins
            AddThrows(20, 0);
            Assert.AreEqual(0, _game.Score);
        }

        [TestMethod]
        public void TestHitAllThreePinsPerThrow()
        {
            AddThrows(20, 3);

            //expected  = 20 * 3 = 60 
            Assert.AreEqual(60, _game.Score);
        }

        [TestMethod]
        public void TestMakingOnlyOneSpare()
        {
            AddSpare();
            AddThrows(18, 0);

            //expected  = 2 * 5 + 18 * 0 = 10 
            Assert.AreEqual(10, _game.Score);
        }

        [TestMethod]
        public void TestMakingASpareThenAllThree()
        {
            AddSpare();
            AddThrows(18, 3);

            //expected  = (2 * 5 + 3) + (18 * 3) = 13 + 54 = 67
            Assert.AreEqual(67, _game.Score);
        }

        [TestMethod]
        public void TestMakingOnlyOneStrike()
        {
            AddStrike();
            AddThrows(1, 4);
            AddThrows(17, 0);

            //expected  = (1 * 10 + 4 + 0) + (4) = 18
            Assert.AreEqual(18, _game.Score);
        }

        [TestMethod]
        public void TestMakingAStrikeThenAllThree()
        {
            AddStrike();
            AddThrows(18, 3);

            //expected  = (1 * 10 + 3 + 3) + (18 * 3) = 16 + 54 = 70
            Assert.AreEqual(70, _game.Score);
        }

        [TestMethod]
        public void TestMakingASpareThenAStrike()
        {
            AddSpare();
            AddStrike();
            AddThrows(16, 0);

            //expected  = (1 * 10 + 10) + (10 * 1 + 0 + 0) = 20 + 10 = 30
            Assert.AreEqual(30, _game.Score);
        }

        [TestMethod]
        public void TestMakingThePerfectGame()
        {
            AddStrikes(12);

            // Perfect Game Score : 300
            Assert.AreEqual(300, _game.Score);
        }
        #endregion TestMethods
        
        #region private methods
        private void AddThrows(int numberOfThrows, int numberOfFalledPins)
        {
            for (var i = 0; i < numberOfThrows; i++)
            {
                _game.AddThrow(numberOfFalledPins);
            }
        }

        private void AddSpare()
        {
            AddThrows(2, 5);
        }
        private void AddStrike()
        {
            AddThrows(1, 10);
        }

        private void AddStrikes(int numberOfStrikes)
        {
            for (var i = 0; i < numberOfStrikes; i++)
            {
                AddStrike();
            }
        }
        #endregion private methods
    }
}
