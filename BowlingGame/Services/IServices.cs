namespace BowlingGame.Services
{
    public interface IServices
    {
        bool IsValidated();
        int GetBonus();
        ScoreDetails GetScoreDetails();
    }
}
