using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
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

            StartNewGameCommand = new RelayCommand<MainBoardViewModel>(x => StartNewGame());

            NextTurnCommand = new RelayCommand<MainBoardViewModel>(x => { });
        }

        private void StartNewGame()
        {
            gameEngine.StartNewGame();

            OnPropertyChanged("Tiles");
            OnPropertyChanged("Players");
        }

        public ICommand StartNewGameCommand { get; private set; }

        public ICommand NextTurnCommand { get; private set; }

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

    class RelayCommand<T> : ICommand
    {
        private readonly Predicate<T> canExecute;
        private readonly Action<T> execute;

        public RelayCommand(Action<T> action)
            : this(x => true, action)
        {
            execute = action;
        }

        public RelayCommand(Predicate<T> canExecute, Action<T> execute)
        {
            this.canExecute = canExecute;
            this.execute = execute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return canExecute((T)parameter);
        }

        public void UpdateCanExecuteState()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, new EventArgs());
            }
        }

        public void Execute(object parameter)
        {
            execute((T)parameter);

            UpdateCanExecuteState();
        }
    }
}