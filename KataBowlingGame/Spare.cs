using System.Collections.Generic;

namespace KataBowlingGame
{
    public class Spare : Frame
    {
        public Spare(IList<Throw> throws, int firstThrowFalledPins, int secondThrowFalledPins) : base(throws)
        {
            Throws.Add(new Throw(firstThrowFalledPins));
            Throws.Add(new Throw(secondThrowFalledPins));
        }

        public override int GetScore()
        {
            return 10 + FirstThrowBonus();
        }

        protected override int ThrowsCount()
        {
            return 2;
        }
    }
}
