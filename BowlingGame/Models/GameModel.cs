namespace BowlingGame.Models
{
    using System.Collections.Generic;
    using System.Web;
    using System;

    public class GameModel
    {
        public int CurrentFrame = 0;
        private bool _isFirstThrow = true;
        private readonly BowlerModel _bowler = new BowlerModel();
        public IList<ThrowsModel> Throws { get; set; }

        public event EventHandler NumberChanged;

        public int CurrentFrameNumber
        {
            get;
            private set;
        }

        public List<ThrowsModel> GetThrows()
        {
            Throws = HttpContext.Current.Application["throwsList"] == null 
                ? new List<ThrowsModel>() 
                : new List<ThrowsModel>((List<ThrowsModel>) HttpContext.Current.Application["throwsList"]);

            return Throws as List<ThrowsModel>;
        }

        public List<ThrowsModel> CreateThrows(ThrowsModel currentThrow)
        {
            Throws = GetThrows();
            Throws.Add(currentThrow);
            HttpContext.Current.Application["throwsList"] = Throws;

            return Throws as List<ThrowsModel>; 
        }

        public int Score
        {
            get { return ScoreForFrame(CurrentFrame); }
        }

        public void Add(int pins)
        {
            _bowler.AddThrow(pins);
            AdjustCurrentFrame(pins);            
        }

        private void AdjustCurrentFrame(int pins)
        {
            if (LastBallInFrame(pins))
                AdvanceFrame();
            else
                _isFirstThrow = false;
        }

        private bool LastBallInFrame(int pins)
        {
            return Strike(pins) || (!_isFirstThrow);
        }

        private bool Strike(int pins)
        {
            return (_isFirstThrow && pins == 10);
        }

        private void AdvanceFrame()
        {
            CurrentFrame++;
            if (CurrentFrame > 10)
                CurrentFrame = 10;

            CurrentFrameNumber = CurrentFrame;
        }

        public int ScoreForFrame(int theFrame)
        {
            return _bowler.ScoreForFrame(theFrame);
        }
    }
}