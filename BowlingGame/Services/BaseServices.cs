namespace BowlingGame.Services
{
    using Models;
    using System.Collections.Generic;

    public abstract class BaseServices : IServices
    {
        private readonly GameModel _gameModel;
        protected List<int> ListRolls
        {
            set { _gameModel.ListRolls = value; }
            get { return _gameModel.ListRolls; }
        }

        public GameModel GameModel
        {
            get { return _gameModel; }
        }

        protected BaseServices(List<int> listRolls, int frame)
        {
            _gameModel = new GameModel(listRolls, frame);
        }

        public abstract bool IsValidated();

        public abstract int GetBonus();

        public abstract ScoreDetails GetScoreDetails();
    }
}
