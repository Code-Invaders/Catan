using System;
using System.Collections.Generic;

namespace CodeInvaders.Catan
{
    public class TileSetFactory : ITileSetFactory
    {
        private readonly IChitSetFactory chitSetFactory;
        private readonly Random random = new Random();

        public TileSetFactory(IChitSetFactory chitSetFactory)
        {
            this.chitSetFactory = chitSetFactory;
        }


        public IEnumerable<Tile> CreateTiles(int tileCount)
        {
            var chits = new Stack<Chit>( chitSetFactory.CreateChits(tileCount) ); 
            do
            {
                yield return MakeRandomTile(chits.Pop());
                tileCount--;
            } while (tileCount > 0);
        }

        private Tile MakeRandomTile(Chit chit)
        {
            var next = random.Next(0, Enum.GetValues(typeof(Resource)).Length - 1);

            return new Tile((Resource)next, chit);
        }
    }
}