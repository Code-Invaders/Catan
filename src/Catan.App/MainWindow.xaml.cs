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
            DataContext = new MainBoardViewModel(new TileFactory(new ChitFactory(10).StandardOrderedNumberSet).GetTiles(9));
        }

        private void StartNewGame(object sender, ExecutedRoutedEventArgs e)
        {
            DataContext = new MainBoardViewModel(new TileFactory(new ChitFactory(10).StandardOrderedNumberSet).GetTiles(9));
        }

        private void ChangeTurn(object sender, ExecutedRoutedEventArgs e)
        {
            DataContext = new MainBoardViewModel(new TileFactory(new ChitFactory(10).StandardOrderedNumberSet).GetTiles(9));
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

        public MainBoardViewModel(IEnumerable<TileViewModel> tiles)
        {
            Tiles = tiles;
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
