namespace BowlingGame.Tests.Controllers
{
    using NUnit.Framework;
    using Services;

    [TestFixture]
    public class BowlingGameTest
    {
        private readonly BowlingGame _bowlingGame;

        public BowlingGameTest()
        {
            _bowlingGame = new BowlingGame();
        }


        [Test]
        public void should_be_score_7_if_pins_1_and_6()
        {
            _bowlingGame.Roll(1);
            _bowlingGame.Roll(6);
            EmptyHits(18);
            var score = _bowlingGame.Score();
            Assert.AreEqual(score, 7);
        }


        [Test]
        public void should_be_score_17_when_frame_2_and_pins_4_5_6_2()
        {
            _bowlingGame.Roll(4);
            _bowlingGame.Roll(5);
            _bowlingGame.Roll(6);
            _bowlingGame.Roll(2);
            EmptyHits(16);
            var score = _bowlingGame.Score();
            Assert.AreEqual(score, 17);
        }

        [Test]
        public void should_be_score_29_when_frame_3_with_spare()
        {
            _bowlingGame.Roll(1);
            _bowlingGame.Roll(4);
            _bowlingGame.Roll(4);
            _bowlingGame.Roll(5);

            SpareHite();

            _bowlingGame.Roll(5);
            EmptyHits(13);
            var score = _bowlingGame.Score();

            Assert.AreEqual(score, 34);
        }

        [Test]
        public void should_be_18_when_spare()
        {
            SpareHite();

            _bowlingGame.Roll(4);

            EmptyHits(17);

            var score = _bowlingGame.Score();
            Assert.AreEqual(score, 18);
        }

        [Test]
        public void should_be_26_when_strake()
        {
            StrakeHite();

            _bowlingGame.Roll(4);
            _bowlingGame.Roll(4);

            EmptyHits(16);

            var score = _bowlingGame.Score();
            Assert.AreEqual(score, 26);
        }


        private void EmptyHits(int count)
        {
            for (var i = 0; i < count; i++)
            {
                _bowlingGame.Roll(0);
            }
        }

        private void SpareHite()
        {
            _bowlingGame.Roll(6);
            _bowlingGame.Roll(4);
        }

        private void StrakeHite()
        {
            _bowlingGame.Roll(10);
        }

    }
}
