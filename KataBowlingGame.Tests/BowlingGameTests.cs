using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KataBowlingGame.Tests
{
    [TestClass]
    public class BowlingGameTests
    {
        #region fields
        private BowlingGame _game;
        #endregion fields

        #region Test Methods
        [TestInitialize]
        public void Initialize()
        {
            _game = new BowlingGame();
        }

        [TestMethod, ExpectedExceptionWithMessage(typeof(InvalidOperationException), "you cannot make more than 23 throws in a game")]
        public void ShouldMakeErrorWhenNumberOfThrowsMoreThan23()
        {
            for (int i = 0; i < 13; i++)
            {
                _game.AddBasicFrame(3, 4);
            }
        }

        [TestMethod, ExpectedExceptionWithMessage(typeof(ArgumentException), "your throw is incorrect, the falled pins (-3) must be between 0 and 10")]
        public void ShouldMakeErrorWhenNumberOfFalledPinsIsNegative()
        {
            _game.AddBasicFrame(-3, 4);
        }

        [TestMethod, ExpectedExceptionWithMessage(typeof(ArgumentException), "the sum of falled pins in a frame must be between 0 and 10")]
        public void ShouldMakeErrorWhenSumOfFalledPinsIsUpperThan10()
        {
            _game.AddBasicFrame(8, 4);
        }

        [TestMethod, ExpectedExceptionWithMessage(typeof(ArgumentException), "this is not a spare !!")]
        public void ShouldMakeErrorWhenSumOfFalledPinsInSpareIsNot10()
        {
            _game.AddSpare(4, 4);
        }
        [TestMethod, ExpectedExceptionWithMessage(typeof(ArgumentException), "this is a spare and not a basic frame !!")]
        public void ShouldMakeErrorWhenTheSumOfFalledPinsInANormalFrameIs10()
        {
            _game.AddBasicFrame(5, 5);
        }

        [TestMethod, ExpectedExceptionWithMessage(typeof(InvalidOperationException), "you cannot make a bonus frame before you finish your 10 frames")]
        public void ShouldMakeErrorWhenPlayingTheBonusFrameBeforeThe10Frames()
        {
            _game.AddBonusFrame(5);
        }


        [TestMethod]
        public void ShouldGetZeroPointsWhenGutterBalls()
        {
            //game with 20 throws of 0 falled pins
            AddManyBasicFrames(10, 0, 0);
            Assert.AreEqual(0, _game.Score);
        }

        [TestMethod]
        public void ShouldGet60PointsWhenFallingThreePinsInAllGame()
        {
            AddManyBasicFrames(10, 3, 3);
            //expected  = 10 * (3+3) = 60 
            Assert.AreEqual(60, _game.Score);
        }
        [TestMethod]
        public void ShouldGetScoreOfTenWhenPlayingOnlyOneSpareAndGutterBalls()
        {
            _game.AddSpare(5, 5);
            AddManyBasicFrames(9, 0, 0);

            //expected  = (5 + 5 + 0 ) + 9 * (0+0) = 10
            Assert.AreEqual(10, _game.Score);
        }

        [TestMethod]
        public void ShouldGetScoreOfTenWhenPlayingOnlyOneStrikeAndGutterBalls()
        {
            _game.AddStrike();
            AddManyBasicFrames(9, 0, 0);

            //expected  = (10 + 0 + 0) + 9 * (0+0) = 10
            Assert.AreEqual(10, _game.Score);
        }
        [TestMethod]
        public void ShouldGetBonusNextThrowWhenPlayingASpare()
        {
            _game.AddSpare(5, 5);
            _game.AddBasicFrame(4, 2);
            AddManyBasicFrames(8, 0, 0);
            //expected  =  spare (2 * 5 + 4) + basicFrame (4+2) + 8 * 0 = 20 
            Assert.AreEqual(20, _game.Score);
        }

        [TestMethod]
        public void ShouldGetBonusNextFrameWhenPlayingAStrike()
        {
            _game.AddStrike();
            _game.AddBasicFrame(4, 2);
            AddManyBasicFrames(8, 0, 0);
            //expected  =  strike (10 + 4 + 2) + basicFrame (4+2) + 8 * 0 = 22 
            Assert.AreEqual(22, _game.Score);
        }

        [TestMethod]
        public void ShouldGetScoreOfBonusFrameWhenSpareInTheLastFrame()
        {
            AddManyBasicFrames(9, 0, 0);
            _game.AddSpare(5,5);
            _game.AddBonusFrame(5);
            //expected  = (9 * 0) + (5 + 5 + 5) = 15
            Assert.AreEqual(15, _game.Score);
        }
        [TestMethod]
        public void ShouldGetTheScoreOfBonusFrameWhenStrikeInTheLastFrame()
        {
            AddManyBasicFrames(9, 0, 0);
            _game.AddStrike();
            _game.AddBonusFrame(5);
            _game.AddBonusFrame(5);
            //expected  = (9 * 0) + (10 + 5 + 5) = 20
            Assert.AreEqual(20, _game.Score);
        }

        [TestMethod]
        public void ShouldGet200PointsWhenAlternatingSparesAndStrikes()
        {
            for (int i = 0; i < 5; i++)
            {
                _game.AddSpare(5, 5);
                _game.AddStrike();
            }
            _game.AddBonusFrame(5);
            _game.AddBonusFrame(5);
            //expected  = 4 * ( (5 + 5 + 10) + (10 + 5 + 5) ) = 200
            Assert.AreEqual(200, _game.Score);
        }

        [TestMethod]
        public void ShouldGet300PointsWhenPlayingThePerfectGame()
        {
            for (int i = 0; i < 10; i++)
            {
                _game.AddStrike();
            }
            _game.AddBonusFrame(10);
            _game.AddBonusFrame(10);

            // Perfect Game Score = 300
            Assert.AreEqual(300, _game.Score);
        }
        #endregion Test Methods

        #region Private Methods
        private void AddManyBasicFrames(int numberOfFrames, int firstThrowPoints, int secondThrowPoints)
        {
            for (var i = 0; i < numberOfFrames; i++)
            {
                _game.AddBasicFrame(firstThrowPoints, secondThrowPoints);
            }
        }
        #endregion Private Methods
    }
}
