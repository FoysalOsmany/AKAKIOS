namespace BowlingGame.Services
{
    using System.Collections.Generic;

    public class SpareServices : BaseServices
    {
        public SpareServices(List<int> listRolls, int frame)
            : base(listRolls, frame) { }

        public override int GetBonus()
        {
            return ListRolls[GameModel.Frame + 2];
        }

        public override bool IsValidated()
        {
            return ListRolls[GameModel.Frame] + ListRolls[GameModel.Frame + 1] == 10;
        }

        public override ScoreDetails GetScoreDetails()
        {
            int sum = 10 + GetBonus();
            GameModel.Frame += 2;
            return new ScoreDetails(sum, GameModel.Frame);
        }
    }
}
