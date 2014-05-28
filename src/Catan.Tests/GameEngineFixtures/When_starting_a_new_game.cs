using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace CodeInvaders.Catan.Tests.GameEngineFixtures
{
    [TestFixture]
    class When_starting_a_new_game
    {
        private GameEngine gameEngine;

        [SetUp]
        public void SetUp()
        {
            var tileFactory = Substitute.For<ITileSetFactory>();

            tileFactory.CreateTiles(Arg.Any<int>()).Returns(new[] { CreateTile(), CreateTile(), CreateTile() });

            gameEngine = new GameEngine(tileFactory);

            gameEngine.StartNewGame();
        }

        [Test]
        public void Should_have_a_set_of_tiles()
        {
            gameEngine.Tiles.Should().HaveCount(3);
        }

        [Test]
        public void Should_have_a_set_of_players()
        {
            gameEngine.Players.Should().HaveCount(4);
        }


        private Tile CreateTile()
        {
            return new Tile(Resource.Brick, new Chit(1));
        }
    }
}