namespace BowlingGame.Services
{
    public class ScoreDetails
    {
        public int score { get; set; }
        public int frame { get; set; }

        public ScoreDetails(int score, int frame)
        {
            this.score = score;
            this.frame = frame;
        }
    }
}
