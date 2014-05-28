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
            var gameEngine = new GameEngine(new TileSetFactory(new ChitSetFactory()));

            DataContext = new MainBoardViewModel(gameEngine);
        }

        private MainBoardViewModel Model
        {
            get { return (MainBoardViewModel) DataContext; }
        }

        private void StartNewGame(object sender, ExecutedRoutedEventArgs e)
        {
            Model.StartNewGame();
        }

        private void ChangeTurn(object sender, ExecutedRoutedEventArgs e)
        {
            Model.NextTurn();
        }
    }

    public static class GameCommands
    {
        public static readonly RoutedUICommand NewGame = new RoutedUICommand("New Game", "NewGame", typeof(MainWindow));

        public static readonly RoutedUICommand NextTurn = new RoutedUICommand("Next Turn", "NextTurn",typeof(MainWindow));
    }
}
