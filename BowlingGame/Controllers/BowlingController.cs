namespace BowlingGame.Controllers
{
    using System;
    using System.Web.Mvc;
    using Models;

    public class BowlingController : Controller
    {
        private GameModel game;
        
        public ActionResult Play() {
            if (game == null)
            {
                game = new GameModel();
            }

            game.Throws = game.GetThrows();
                
            ViewBag.gameScore = game.Score;

            return View(game);
        }

        [HttpPost]
        public ActionResult NextPlay(GameModel game, int ball)
        {
            if (game == null)
            {
                game = new GameModel();
            }
            
            int ballStrikes = ball;

            
            game.Add(ballStrikes);

            ViewBag.gameScore = game.Score;

            var currentThrow = new ThrowsModel(
                ballStrikes,
                game.CurrentFrameNumber,
                game.ScoreForFrame(game.CurrentFrameNumber)
            );

            game.CreateThrows(currentThrow);

            game.Throws = game.GetThrows();

            return View("Play", game);
        }
    }
}
