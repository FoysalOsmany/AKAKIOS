namespace BowlingGame.Services
{
    using System.Collections.Generic;

    public class StrikeServices : BaseServices
    {
        public StrikeServices(List<int> listRolls, int frame)
            : base(listRolls, frame) { }

        public override bool IsValidated()
        {
            return ListRolls[GameModel.Frame] == 10;
        }

        public override int GetBonus()
        {
            return 10 + ListRolls[GameModel.Frame + 1] + ListRolls[GameModel.Frame + 2];
        }

        public override ScoreDetails GetScoreDetails()
        {
            int sum = GetBonus();
            GameModel.Frame++;
            return new ScoreDetails(sum, GameModel.Frame);
        }
    }
}
