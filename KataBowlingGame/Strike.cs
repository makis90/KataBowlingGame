using System.Collections.Generic;
namespace KataBowlingGame
{
    public class Strike : Frame
    {
        public Strike(IList<Throw> throws) : base(throws)
        {
            Throws.Add(new Throw(10));
        }

        public override int GetScore()
        {
            return 10 + FirstThrowBonus() + SecondThrowBonus();
        }

        protected override int ThrowsCount()
        {
            return 1;
        }
    }
}
