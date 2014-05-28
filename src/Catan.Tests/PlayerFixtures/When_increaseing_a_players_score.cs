using NUnit.Framework;
using FluentAssertions;

namespace CodeInvaders.Catan.Tests.PlayerFixtures
{
    [TestFixture]
    internal class When_increaseing_a_players_score
    {
        [Test]
        public void should_increase_score()
        {
            var player = new Player("Sue");
            
            player.UpsTheScore(6);

            player.Score.Should().Be(6);
        }
        [Test]
        public void should_increase_score_more_than_once()
        {
            var player = new Player("Sue");

            player.UpsTheScore(6);
            player.UpsTheScore(5);

            player.Score.Should().Be(11);
        }
    }
}