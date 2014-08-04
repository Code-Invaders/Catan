using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using CodeInvaders.Catan.App.Annotations;

namespace CodeInvaders.Catan.App
{
    public class GamePlayViewModel : INotifyPropertyChanged
    {
        private readonly GameEngine gameEngine;

        public IEnumerable<PlayerViewModel> Players { get { return gameEngine.Players.Select(x => new PlayerViewModel(x, IsPlayerActive)); } }

        public IEnumerable<TileViewModel> Tiles { get { return gameEngine.Tiles.Select(x => new TileViewModel(x)); } }

        public bool IsGameInProgress { get { return gameEngine.IsGameInProgress; } }

        public GamePlayViewModel(GameEngine gameEngine)
        {
            this.gameEngine = gameEngine;

            StartNewGameCommand = new RelayCommand<GamePlayViewModel>(x => StartNewGame());

            NextTurnCommand = new RelayCommand<GamePlayViewModel>(x => x.IsGameInProgress, x => NextTurn());
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

        public RelayCommand<GamePlayViewModel> StartNewGameCommand { get; private set; }

        public RelayCommand<GamePlayViewModel> NextTurnCommand { get; private set; }

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