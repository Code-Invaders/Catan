using System.Collections.Generic;

namespace CodeInvaders.Catan
{
    public interface ITileSetFactory
    {
        IEnumerable<Tile> CreateTiles(int tileCount);
    }
}