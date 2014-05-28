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

        public IEnumerable<PlayerViewModel> Players { get { return gameEngine.Players.Select(x => new PlayerViewModel(x)); } }
        public IEnumerable<TileViewModel> Tiles { get { return gameEngine.Tiles.Select(x => new TileViewModel(x)); } }

        public MainBoardViewModel(GameEngine gameEngine)
        {
            this.gameEngine = gameEngine;
        }

        public void StartNewGame()
        {
            gameEngine.StartNewGame();

            OnPropertyChanged("Tiles");
            OnPropertyChanged("Players");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public void NextTurn()
        {
            gameEngine.NextTurn();
        }
    }
}