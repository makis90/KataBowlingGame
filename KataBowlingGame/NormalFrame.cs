using System.Collections.Generic;

namespace KataBowlingGame
{
    public class BasicFrame : Frame
    {
        private readonly int _firstThrowFalledPins;
        private readonly int _secondThrowFalledPins;

        public BasicFrame(IList<Throw> throws, int firstThrowFalledPins, int secondThrowFalledPins) : base(throws)
        {
            _firstThrowFalledPins = firstThrowFalledPins;
            _secondThrowFalledPins = secondThrowFalledPins;
            Throws.Add(new Throw(firstThrowFalledPins));
            Throws.Add(new Throw(secondThrowFalledPins));
        }

        public override int GetScore()
        {
            return _firstThrowFalledPins + _secondThrowFalledPins;
        }

        protected override int ThrowsCount()
        {
            return 2;
        }
    }
}
