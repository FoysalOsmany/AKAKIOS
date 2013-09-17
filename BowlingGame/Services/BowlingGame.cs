using System.Collections.Generic;

namespace BowlingGame.Services
{
    using Models;

    public class BowlingGame
    {
        private readonly GameModel _gameModel;

        public BowlingGame()
        {
            _gameModel = new GameModel();
        }

        public BowlingGame(GameModel gameModel)
        {
            _gameModel = gameModel;
        }

        private const int FramesNumber = 10;
        
        private const int StrikeNumber = 10;
        
        private const int SpareNumber = 10;
        
        public void Roll(int pins)
        {
            _gameModel.ListRolls.Add(pins);
        }

        public int Score()
        {
            var score = 0;
            var frame = 0;
            for (var i = 0; i < FramesNumber; i++)
            {
                if (IsSpare(frame))
                {
                    score += SpareNumber + SpareBonus(frame);
                    frame += 2;
                }
                else if (IsStrike(frame))
                {
                    score += StrikeBonus(frame);
                    frame++;
                }
                else
                {
                    score += SumOfBallsInFrame(frame);
                    frame += 2;
                }
            }
            return score;
        }

        public int Score2()
        {
            ScoreDetails scoreDetails = new ScoreDetails(0, 0);

            for (var i = 0; i < FramesNumber; i++)
            {
                var listService = new List<IServices>
                                                  {
                                                      new SpareServices(_gameModel.ListRolls, scoreDetails.frame),
                                                      new StrikeServices(_gameModel.ListRolls, scoreDetails.frame),
                                                      new CommonServices(_gameModel.ListRolls, scoreDetails.frame)
                                                  };
                listService.ForEach(x =>
                                        {
                                            if (x.IsValidated())
                                            {
                                                var scoreD = x.GetScoreDetails();
                                                scoreDetails.score += scoreD.score;
                                                scoreDetails.frame += scoreD.frame;
                                            }
                                        });
            }
            return scoreDetails.score;
        }

        bool IsStrike(int frame)
        {
            return _gameModel.ListRolls[frame] == StrikeNumber;
        }

        bool IsSpare(int frame)
        {
            return _gameModel.ListRolls[frame] + _gameModel.ListRolls[frame + 1] == SpareNumber;
        }

        int SumOfBallsInFrame(int frame)
        {
            return _gameModel.ListRolls[frame + 1] + _gameModel.ListRolls[frame];
        }
        int SpareBonus(int frame)
        {
            return _gameModel.ListRolls[frame + 2];
        }

        int StrikeBonus(int frame)
        {
            return StrikeNumber + _gameModel.ListRolls[frame + 1] + _gameModel.ListRolls[frame + 2];
        }
    }
}
