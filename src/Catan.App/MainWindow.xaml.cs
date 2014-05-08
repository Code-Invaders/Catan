using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Catan.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainBoardViewModel();
        }
    }

    public class MainBoardViewModel
    {
        public IEnumerable<TileViewModel> Tiles
        {
            get
            {
                yield return new TileViewModel { Resource = Resource.Brick};;
                yield return new TileViewModel { Resource = Resource.Grain};;
                yield return new TileViewModel { Resource = Resource.Sheep};;
                yield return new TileViewModel { Resource = Resource.Wood};;
                yield return new TileViewModel { Resource = Resource.Ore};;
                yield return new TileViewModel { Resource = Resource.Brick};;
                yield return new TileViewModel { Resource = Resource.Grain};;
                yield return new TileViewModel { Resource = Resource.Brick};;
                yield return new TileViewModel { Resource = Resource.Wood};;
            }
        } 
    }

    public class TileViewModel
    {
        public Resource Resource { get; set; }
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
