using System.Collections.Generic;


namespace KataBowlingGame
{
    public abstract class Frame : IFrame
    {
        private readonly int _startThrowIndex;
        protected IList<Throw> Throws { get; private set; }

        protected Frame(IList<Throw> throws)
        {
            Throws = throws;
            _startThrowIndex = throws.Count;
        }
        abstract public int GetScore();
        abstract protected int ThrowsCount();

        protected int FirstThrowBonus()
        {
            return Throws[_startThrowIndex + ThrowsCount()].Score;
        }
        protected int SecondThrowBonus()
        {
            return Throws[_startThrowIndex + ThrowsCount() + 1].Score;
        }
    }

}
