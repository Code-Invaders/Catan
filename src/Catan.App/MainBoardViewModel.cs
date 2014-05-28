using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using CodeInvaders.Catan.App.Annotations;

namespace CodeInvaders.Catan.App
{
    public class MainBoardViewModel : INotifyPropertyChanged
    {
        private readonly GameEngine gameEngine;

        public IEnumerable<PlayerViewModel> Players { get { return gameEngine.Players.Select(x => new PlayerViewModel(x, IsPlayerActive)); } }

        public IEnumerable<TileViewModel> Tiles { get { return gameEngine.Tiles.Select(x => new TileViewModel(x)); } }

        public bool IsGameInProgress { get { return gameEngine.IsGameInProgress; } }

        public MainBoardViewModel(GameEngine gameEngine)
        {
            this.gameEngine = gameEngine;

            StartNewGameCommand = new RelayCommand<MainBoardViewModel>(x => StartNewGame());

            NextTurnCommand = new RelayCommand<MainBoardViewModel>(x => x.IsGameInProgress, x => NextTurn());
        }

        private void StartNewGame()
        {
            gameEngine.StartNewGame();

            OnPropertyChanged("Tiles");
            OnPropertyChanged("Players");
            NextTurnCommand.UpdateCanExecuteState();
        }

        private bool IsPlayerActive(Player player)
        {
            return gameEngine.CurrentPlayer == player;
        }

        public RelayCommand<MainBoardViewModel> StartNewGameCommand { get; private set; }

        public RelayCommand<MainBoardViewModel> NextTurnCommand { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private void NextTurn()
        {
            gameEngine.NextTurn();

            OnPropertyChanged("Players");
        }
    }
}