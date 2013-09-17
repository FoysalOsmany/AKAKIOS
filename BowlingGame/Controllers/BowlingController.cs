namespace BowlingGame.Controllers
{
    using System.Web.Mvc;
    using Models;
    using Services;

    public class BowlingController : Controller
    {
        private readonly BowlingGame _game;

        private readonly GameModel gameModel;
        public BowlingController()
        {
            gameModel = new GameModel();
            _game = new BowlingGame();
            
        }

        public ActionResult Play()
        {
            
            _game.Roll(1);
            _game.Score();

            return View(gameModel);
        }

        [HttpPost]
        public ActionResult NextPlay(GameModel gameModel, int ball)
        {
            _game.Roll(ball);
            _game.Score();

            return View("Play", gameModel);
        }
    }
}
