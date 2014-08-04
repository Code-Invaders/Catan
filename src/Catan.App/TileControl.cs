using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace CodeInvaders.Catan.App
{
    class TileControl : DrawingVisual
    {
        private readonly int myLeft;
        private readonly int myTop;
        private readonly int myWidth;
        private readonly int myHeight;
        private readonly TileViewModel tileViewModel;
        readonly List<Point> lines = new List<Point>();

        public TileControl(int left, int top, int width, int height, TileViewModel tileViewModel)
        {
            myLeft = left;
            myTop = top;
            myWidth = width;
            myHeight = height;
            this.tileViewModel = tileViewModel;
            BuildHex();
            DisplayHex();
        }

        private static Brush ConvertTileToBrush(TileViewModel tile)
        {
            switch (tile.Resource)
            {
                case Resource.Wood:
                    return new SolidColorBrush(Colors.DarkGreen);
                case Resource.Brick:
                    return new SolidColorBrush(Colors.Orange);
                case Resource.Grain:
                    return new SolidColorBrush(Colors.Yellow);
                case Resource.Ore:
                    return new SolidColorBrush(Colors.Gray);
                case Resource.Sheep:
                    return new SolidColorBrush(Colors.LightGreen);

                default:
                    return new SolidColorBrush(Colors.DarkRed);
            }
        }
        private void BuildHex()
        {
            var p = new Point(Math.Round(myWidth / 4.0) + myLeft, 0 + myTop);
            lines.Add(p);
            p = new Point(Math.Round((myWidth * 3.0) / 4.0) - 1 + myLeft, 0 + myTop);
            lines.Add(p);
            p = new Point(myWidth + myLeft - 1, Math.Round(myHeight / 2.0) + myTop - 1);
            lines.Add(p);
            p = new Point(Math.Round((myWidth * 3.0) / 4.0) + myLeft - 1, myHeight + myTop - 1);
            lines.Add(p);
            p = new Point(Math.Round(myWidth / 4.0) + myLeft, myHeight + myTop - 1);
            lines.Add(p);
            p = new Point(0 + myLeft, Math.Round(myHeight / 2.0) + myTop);
            lines.Add(p);
        }
        private void DisplayHex()
        {
            using (DrawingContext dc = RenderOpen())
            {
                dc.DrawGeometry(ConvertTileToBrush(tileViewModel), null, BuildGeo());
                var typeface = new Typeface(new FontFamily("Arial"), FontStyles.Normal, FontWeights.Normal, FontStretches.Condensed);
                dc.DrawText(new FormattedText(tileViewModel.Chit.IdentifyingNumber.ToString(), CultureInfo.CurrentUICulture, FlowDirection.LeftToRight, typeface, 10, Brushes.Black), new Point(myLeft + (myWidth / 2), myTop + (myHeight / 2)));
            }
        }
        private Geometry BuildGeo()
        {
            var pf = new PathFigure {StartPoint = lines[0]};
            for (int x = 1; x < lines.Count; x++)
            {
                pf.Segments.Add(new LineSegment(lines[x], true));
            }
            var pg = new PathGeometry();
            pg.Figures.Add(pf);
            return pg;
        }
    }
}