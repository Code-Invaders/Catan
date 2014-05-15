using System;
using System.Collections.Generic;

namespace CodeInvaders.Catan.App
{
    public class TileFactory
    {

        private Random random = new Random();

        private Stack<Chit> chits;

        public TileFactory(IEnumerable<Chit> chits)
        {
            this.chits = new Stack<Chit>(chits);
        }


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

            return new TileViewModel((Resource) next, chits.Pop());
        }
    }
}