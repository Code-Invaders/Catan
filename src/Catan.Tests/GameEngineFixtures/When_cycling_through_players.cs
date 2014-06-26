using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace CodeInvaders.Catan.Tests.GameEngineFixtures
{
    [TestFixture]
    class When_cycling_through_players
    {
        [Test]
        public void Should_alert_when_won()
        {
            var gameEngine = new GameEngine(new TileSetFactory(new ChitSetFactory()));
            
            gameEngine.StartNewGame();

            Player playerExpectedToWin = gameEngine.Players.First();

            playerExpectedToWin.UpsTheScore(10);

            gameEngine.WinningPLayer.Should().Be(playerExpectedToWin);

        }
    }
}