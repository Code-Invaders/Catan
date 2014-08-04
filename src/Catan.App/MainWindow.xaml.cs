using System.Windows;

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

            DataContext = new GamePlayViewModel(gameEngine);
        }
    }
}
