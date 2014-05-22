using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace CodeInvaders.Catan.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            InitializeModel();
        }

        private void InitializeModel()
        {
            IEnumerable<TileViewModel> tileViewModels = new TileFactory(new ChitFactory(10).StandardOrderedNumberSet).GetTiles(9);

            IEnumerable<PlayerViewModel> playerViewModels = new[]
                {new PlayerViewModel("Player 1"), new PlayerViewModel("Player 2")};


            DataContext = new MainBoardViewModel(tileViewModels, playerViewModels);
        }

        private void StartNewGame(object sender, ExecutedRoutedEventArgs e)
        {
            InitializeModel();
        }

        private void ChangeTurn(object sender, ExecutedRoutedEventArgs e)
        {
            InitializeModel();
        }
    }

    public static class GameCommands
    {
        public static readonly RoutedUICommand NewGame = new RoutedUICommand("New Game", "NewGame", typeof(MainWindow));

        public static readonly RoutedUICommand NextTurn = new RoutedUICommand("Next Turn", "NextTurn",typeof(MainWindow));
    }

    public class MainBoardViewModel
    {
        public IEnumerable<TileViewModel> Tiles { get; set; }

        public IEnumerable<PlayerViewModel> Players { get; set; }

        public MainBoardViewModel(IEnumerable<TileViewModel> tiles, IEnumerable<PlayerViewModel> players)
        {
            Tiles = tiles;
            Players = players;
            
        }
    }

    public class PlayerViewModel
    {
        public int Score { get; set; }

        public string Name { get; set; }

        public PlayerViewModel(string name)
        {
            Name = name;
        }
    }

    public class TileViewModel
    {
        public TileViewModel(Resource next, Chit chit)
        {
            Resource = next;
            Chit = chit;
        }

        public Resource Resource { get; set; }
        public Chit Chit { get; set; }
    }

    public enum Resource
    {
        Brick,
        Grain,
        Sheep,
        Wood,
        Ore
    }
}
