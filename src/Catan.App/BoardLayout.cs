using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace CodeInvaders.Catan.App
{
    class BoardLayout : FrameworkElement
    {
        const int HEX_WIDTH = 90;
        const int HEX_HEIGHT = 80;
        const int HEX_GAP = 0;

        private static readonly List<Tuple<int, int>> HiddenHexes = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0,0), new Tuple<int, int>(0,4),
                new Tuple<int, int>(1,4),
                new Tuple<int, int>(3,4),
                new Tuple<int, int>(4,0), new Tuple<int, int>(4,4),
            };

        private readonly VisualCollection children;

        int hexCols = 5;
        int hexRows = 5;

        public BoardLayout()
        {
            children = new VisualCollection(this);
        }

        public void DrawHexes(IEnumerable<TileViewModel> tiles)
        {
            children.Clear();
            children.Add(CreateBackground());
            var tileEnumerator = tiles.GetEnumerator();
            for (int col = 0; col < hexCols; col++)
            {
                for (int row = 0; row < hexRows; row++)
                {
                    if (HiddenHexes.Any(x => x.Item1 == col && x.Item2 == row)) continue;

                    if (! tileEnumerator.MoveNext()) break;

                    var offset = computeHexOffsets(col, row);
                    var tmpHex = new TileControl(offset.Item1, offset.Item2, HEX_WIDTH, HEX_HEIGHT, tileEnumerator.Current);
                    children.Add(tmpHex);
                }
            }
        }

        private Visual CreateBackground()
        {
            var mapBitmap = new DrawingVisual();
            using (DrawingContext dc = mapBitmap.RenderOpen())
            {
                var aRec = new Rect(0, 0, 400, 400);
                dc.DrawRectangle(Brushes.Blue, new Pen(), aRec);
                return mapBitmap;
            }
        }

        private Tuple<int, int> computeHexOffsets(int col, int row)
        {
            var fCol = (float)col;
            var fRow = (float)row;
            var fWidth = (float)HEX_WIDTH;
            var fHeight = (float)HEX_HEIGHT;
            var fGap = (float)HEX_GAP;

            int x_off = (int)((fCol * (fWidth + fGap)) * 0.75f);
            float y_adjust = (fHeight * 0.5f) * (col % 2);
            int y_off = (int)(fRow * (fHeight + fGap) + y_adjust);

            return new Tuple<int, int>(x_off, y_off);
        }

        protected override int VisualChildrenCount
        {
            get { return children.Count; }
        }

        protected override Visual GetVisualChild(int index)
        {
            if (index < 0 || index >= children.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            return children[index];
        }

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(IEnumerable<TileViewModel>), typeof(BoardLayout), new PropertyMetadata(OnItemsSourcePropertyChanged));

        private static void OnItemsSourcePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var control = sender as BoardLayout;
            if (control != null)
            {
                control.OnItemsSourceChanged((IEnumerable<TileViewModel>)e.NewValue);
            }
        }

        private void OnItemsSourceChanged(IEnumerable<TileViewModel> newValue)
        {
            if (newValue == null) return;

            DrawHexes(newValue);
        }
    }
}