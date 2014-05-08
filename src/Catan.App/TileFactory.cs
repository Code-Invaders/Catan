using System;
using System.Collections.Generic;
using Catan.App;

namespace CodeInvaders.Catan.App
{
    public class TileFactory
    {

        private Random random = new Random();

        public IEnumerable<TileViewModel> GetTiles(int i)
        {
            do
            {
                yield return MakeRandomTile();
                i--;
            } while (i > 0);
        }

        private TileViewModel MakeRandomTile()
        {
            
            var next = random.Next(0, Enum.GetValues(typeof(Resource)).Length - 1);

            return new TileViewModel((Resource) next);
        }
    }
}