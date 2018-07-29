namespace KataBowlingGame
{
    /// <summary>
    /// In this BowlingGame, in each two throws we add a frame to the table ** _frames **
    /// Because of some spesific cases (bonus), in order to calculate the score of each frame we test if there's a bonus (a spare or a strike), 
    /// => then we add the score of the frame to the global score of the game.
    /// In this game a foul is supposed to be a throw with 0 falled pins
    /// </summary>
    public class BowlingGame
    {
        #region fields
        private int[,] _frames = new int[12, 2];
        private int frameIndex = 0;
        private int throwIndex = 0;
        #endregion fields

        public int Score
        {
            get
            {
                return CalculateScore();
            }
        }

        public void AddThrow(int falledPins)
        {
            // if throwIndex is 2 or it's a strike, we pass to the next frame
            if (throwIndex == 2)
            {
                MoveToNextFrame();
            }

            _frames[frameIndex, throwIndex++] = falledPins;

            if (falledPins == 10)
            {
                MoveToNextFrame();
            }
        }


        #region private methods
        private int CalculateScore()
        {
            var score = 0;
            for (var frame = 0; frame < 10; frame++)
            {
                if (IsStrike(frame))
                {
                    score += 10 + StrikeBonus(frame);
                }
                else if (IsSpare(frame))
                {
                    score += 10 + SpareBonus(frame);
                }
                else
                {
                    score += NormalScore(frame);
                }
            }
            return score;
        }

        private void MoveToNextFrame()
        {
            throwIndex = 0;
            frameIndex++;
        }
        private bool IsSpare(int frame)
        {
            return _frames[frame, 0] + _frames[frame, 1] == 10;
        }
        private bool IsStrike(int frame)
        {
            return _frames[frame, 0] == 10;
        }

        private int SpareBonus(int frame)
        {
            return _frames[frame + 1, 0];
        }

        private int StrikeBonus(int frame)
        {
            return _frames[frame + 1, 0] + _frames[frame + 2, 0];
        }

        private int NormalScore(int frame)
        {
            return _frames[frame, 0] + _frames[frame, 1];
        }
        #endregion private methods
    }
}
