using System.Collections.Generic;

namespace KataBowlingGame
{
    public class BonusFrame : Frame
    {
        public BonusFrame(IList<Throw> throws, int falledPins) : base(throws)
        {
            throws.Add(new Throw(falledPins));
        }

        public override int GetScore()
        {
            return 0;
        }

        protected override int ThrowsCount()
        {
            return 1;
        }
    }
}
