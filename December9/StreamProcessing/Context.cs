namespace StreamProcessing
{
    public class Context
    {
        private int _totalScore = 0;
        private int _currLevel = 0;

        public Context(int initialLevel)
        {
            _currLevel = initialLevel;
        }

        public void OpenGroup()
        {
            _currLevel++;
        }

        public void CloseGroup()
        {
            _totalScore += _currLevel;
            _currLevel--;
        }

        public int TotalScore => _totalScore;
    }
}
