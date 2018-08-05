using System;
using System.Collections.Generic;

namespace KataBowlingGame
{
    public class FrameChecker
    {
        private readonly IList<Throw> _throws;
        private readonly IList<IFrame> _frames;
        public FrameChecker(IList<IFrame> frames, IList<Throw> throws)
        {
            _frames = frames;
            _throws = throws;
        }
        public void CheckBasicFrame(int firstThrowFalledPins, int secondThrowFalledPins)
        {
            CheckGame();
            CheckFalledPins(firstThrowFalledPins, secondThrowFalledPins);

            if(firstThrowFalledPins + secondThrowFalledPins == 10)
                throw new ArgumentException("this is a spare and not a basic frame !!");
        }
        public void CheckSpare(int firstThrowFalledPins, int secondThrowFalledPins)
        {
            CheckGame();
            CheckFalledPins(firstThrowFalledPins, secondThrowFalledPins);

            if (firstThrowFalledPins + secondThrowFalledPins != 10)
                throw new ArgumentException("this is not a spare !!");
        }
        public void CheckStrike()
        {
            CheckGame();
        }

        public void CheckBonusFrame(int falledPins)
        {
            CheckThrow(falledPins);
            if(_frames.Count < 10)
                throw new InvalidOperationException("you cannot make a bonus frame before you finish your 10 frames");
        }
        private void CheckGame()
        {
            string maxCountMessage = "you cannot make more than {0} in a game";
            if (_throws.Count > BowlingGame.MaxThrowsCount) throw new InvalidOperationException(string.Format(maxCountMessage, BowlingGame.MaxThrowsCount + " throws"));
            if (_frames.Count > BowlingGame.MaxFramesCount) throw new InvalidOperationException(string.Format(maxCountMessage, BowlingGame.MaxFramesCount + " frames"));
        }

        private void CheckThrow(int falledPins)
        {
            string throwErrorMessage = "your throw is incorrect, the falled pins ({0}) must be between 0 and 10";
            if (falledPins < 0 || falledPins > 10) throw new ArgumentException(string.Format(throwErrorMessage, falledPins));
        }
        private void CheckFalledPins(int firstThrowFalledPins, int secondThrowFalledPins)
        {
            CheckThrow(firstThrowFalledPins);
            CheckThrow(secondThrowFalledPins);
            
            int sumOfThrows = firstThrowFalledPins + secondThrowFalledPins;
            if (sumOfThrows > 10 || sumOfThrows < 0)
                throw new ArgumentException("the sum of falled pins in a frame must be between 0 and 10");
        }
    }
}
