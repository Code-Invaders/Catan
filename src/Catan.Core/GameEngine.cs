using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeInvaders.Catan
{
    public class GameEngine
    {
        Random randomNumber = new Random();

        private readonly ITileSetFactory tileSetFactory;
        private IEnumerator<Player> playerTurns;
        
        public GameEngine(ITileSetFactory tileSetFactory)
        {
            this.tileSetFactory = tileSetFactory;
            Tiles = Enumerable.Empty<Tile>();
            Players = Enumerable.Empty<Player>();
        }

        public void StartNewGame()
        {
            Tiles = tileSetFactory.CreateTiles(19);
            Players = new[] { new Player("Player 1"), new Player("Player 2"), new Player("Player 3"), new Player("Player 4"), };
            playerTurns = Players.GetEnumerator();
            playerTurns.MoveNext();
            IsGameInProgress = true;
        }

        public bool IsGameInProgress { get; private set; }

        public IEnumerable<Tile> Tiles { get; private set; }

        public IEnumerable<Player> Players { get; private set; }

        public Player CurrentPlayer
        {
            get { return playerTurns.Current; }

        }

        public void NextTurn()
        {
            var upscore = randomNumber.Next(0, 3);
            CurrentPlayer.UpsTheScore(upscore);
            if (!playerTurns.MoveNext())
            {
                playerTurns.Reset();
                playerTurns.MoveNext();
            }
        }
    }
}