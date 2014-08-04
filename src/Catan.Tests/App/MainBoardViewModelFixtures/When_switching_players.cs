using System.Linq;
using CodeInvaders.Catan.App;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace CodeInvaders.Catan.Tests.App.MainBoardViewModelFixtures
{
    [TestFixture]
    class When_switching_players
    {
        private GamePlayViewModel gamePlayViewModel;

        [SetUp]
        public void SetUp()
        {
            var gameEngine = new GameEngine(Substitute.For<ITileSetFactory>());

            gamePlayViewModel = new GamePlayViewModel(gameEngine);

            gamePlayViewModel.StartNewGameCommand.Execute(null);
        }

        [Test]
        public void Should_select_the_next_player()
        {
            gamePlayViewModel.NextTurnCommand.Execute(null);

            gamePlayViewModel.Players.Skip(1).First().IsActive.Should().BeTrue();
        }

        [Test]
        public void Should_loop_around_again()
        {
            gamePlayViewModel.NextTurnCommand.Execute(null);
            gamePlayViewModel.NextTurnCommand.Execute(null);
            gamePlayViewModel.NextTurnCommand.Execute(null);
            gamePlayViewModel.NextTurnCommand.Execute(null);

            gamePlayViewModel.Players.First().IsActive.Should().BeTrue();
        }

    }
}