using System.Collections.Generic;

namespace KataBowlingGame
{
    /// <summary>
    /// This is a regular BowlingGame with 10 frames of 2 throws and a bonus frame in case of spare or strike in the last frame
    /// In this game a foul is supposed to be a throw with 0 falled pins
    /// ** _frames ** is the list of frames in the games
    /// ** _throws ** is the list of throws of all frames in the games
    /// </summary>
    public class BowlingGame
    {
        private readonly FrameChecker _frameValidator;
        private readonly IList<IFrame> _frames;
        private readonly IList<Throw> _throws;
        public const int MaxThrowsCount = 23;
        public const int MaxFramesCount = 12;

        public BowlingGame()
        {
            _frames = new List<IFrame>(MaxFramesCount);
            _throws = new List<Throw>(MaxThrowsCount);
            _frameValidator = new FrameChecker(_frames, _throws);
        }
        public int Score
        {
            get
            {
                int score = 0;
                foreach (var frame in _frames)
                {
                    score += frame.GetScore();
                }
                return score;
            }
        }


        public void AddBasicFrame(int firstThrowFalledPins, int secondThrowFalledPins)
        {
            _frameValidator.CheckBasicFrame(firstThrowFalledPins, secondThrowFalledPins);
            _frames.Add(new BasicFrame(_throws, firstThrowFalledPins, secondThrowFalledPins));
        }

        public void AddSpare(int firstThrowFalledPins, int secondThrowFalledPins)
        {
            _frameValidator.CheckSpare(firstThrowFalledPins, secondThrowFalledPins);
            _frames.Add(new Spare(_throws, firstThrowFalledPins, secondThrowFalledPins));
        }

        public void AddStrike()
        {
            _frameValidator.CheckStrike();
            _frames.Add(new Strike(_throws));
        }

        public void AddBonusFrame(int falledPins)
        {
            _frameValidator.CheckBonusFrame(falledPins);
            _frames.Add(new BonusFrame(_throws, falledPins));
        }
    }
}
