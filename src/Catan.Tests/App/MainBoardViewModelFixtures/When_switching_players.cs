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
        private MainBoardViewModel mainBoardViewModel;

        [SetUp]
        public void SetUp()
        {
            var gameEngine = new GameEngine(Substitute.For<ITileSetFactory>());

            mainBoardViewModel = new MainBoardViewModel(gameEngine);

            mainBoardViewModel.StartNewGameCommand.Execute(null);
        }

        [Test]
        public void Should_select_the_next_player()
        {
            mainBoardViewModel.NextTurnCommand.Execute(null);

            mainBoardViewModel.Players.Skip(1).First().IsActive.Should().BeTrue();
        }

        [Test]
        public void Should_loop_around_again()
        {
            mainBoardViewModel.NextTurnCommand.Execute(null);
            mainBoardViewModel.NextTurnCommand.Execute(null);
            mainBoardViewModel.NextTurnCommand.Execute(null);
            mainBoardViewModel.NextTurnCommand.Execute(null);

            mainBoardViewModel.Players.First().IsActive.Should().BeTrue();
        }

    }
}