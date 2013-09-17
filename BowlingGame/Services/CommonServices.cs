namespace BowlingGame.Services
{
    using System.Collections.Generic;

    public class CommonServices : BaseServices
    {
        public CommonServices(List<int> listRolls, int frame)
            : base(listRolls, frame) { }

        public override bool IsValidated()
        {
            return ListRolls[GameModel.Frame] != 10 && ListRolls[GameModel.Frame] + ListRolls[GameModel.Frame + 1] != 10;
        }

        public override int GetBonus()
        {
            return 0;
        }

        public override ScoreDetails GetScoreDetails()
        {
            var score = ListRolls[GameModel.Frame + 1] + ListRolls[GameModel.Frame];
            GameModel.Frame += 2;
            return new ScoreDetails(score, GameModel.Frame);
        }
    }
}