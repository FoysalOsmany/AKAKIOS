namespace BowlingGame.Models
{
    using System.Collections.Generic;
    
    public class GameModel
    {
        public int Score { get; set; }

        public int Frame { get; set; }
        
        public List<int> ListRolls { get; set; }

        public GameModel(int score, int frame, List<int> listRolls)
        {
            this.Score = score;
            this.Frame = frame;
            this.ListRolls = new List<int>(21);
            this.ListRolls = listRolls;
        }

        public GameModel(List<int> listRolls, int frame)
        {
            this.Frame = frame;
            this.ListRolls = listRolls;
        }

        public GameModel()
        {
            this.Score = 0;
            this.Frame = 0;
            this.ListRolls = new List<int>();
        }
    }
}