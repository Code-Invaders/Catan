using System.Collections.Generic;
using System.Linq;

namespace CodeInvaders.Catan
{
    public class GameEngine
    {
        private readonly ITileSetFactory tileSetFactory;
        
        public GameEngine(ITileSetFactory tileSetFactory)
        {
            this.tileSetFactory = tileSetFactory;
            Tiles = Enumerable.Empty<Tile>();
            Players = Enumerable.Empty<Player>();
        }

        public void StartNewGame()
        {
            Tiles = tileSetFactory.CreateTiles(9);
            Players = new[] { new Player("Player 1"), new Player("Player 2"), new Player("Player 3"), new Player("Player 4"), };
            Players.First().IsActive = true;
        }

        public IEnumerable<Tile> Tiles { get; private set; }

        public IEnumerable<Player> Players { get; private set; }

        public void NextTurn()
        {
        }
    }
}