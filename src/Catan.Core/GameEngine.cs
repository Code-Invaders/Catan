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
            Tiles = tileSetFactory.CreateTiles(19).ToArray();
            Players = new[] { CreatePlayer("Player 1"), CreatePlayer("Player 2"), CreatePlayer("Player 3"), CreatePlayer("Player 4"), };
            playerTurns = Players.GetEnumerator();
            playerTurns.MoveNext();
            IsGameInProgress = true;
        }

        private Player CreatePlayer(string name)
        {
            var player = new Player(name);

            player.ScoreIncrease += PlayersScoreIncreases;

            return player;
        }

        private void PlayersScoreIncreases(object sender, ScoreIncreaseEvent e)
        {
            if (e.Score == 10)
            {
                WinningPLayer = e.Player;
            }
        }

        public bool IsGameInProgress { get; private set; }

        public IEnumerable<Tile> Tiles { get; private set; }

        public IEnumerable<Player> Players { get; private set; }

        public Player CurrentPlayer
        {
            get { return playerTurns.Current; }

        }

        public Player WinningPLayer { get; private set; }

        public void NextTurn()
        {
            var upscore = randomNumber.Next(0, 3);
            CurrentPlayer.UpsTheScore(upscore);
            
            //Do some work

            if (!playerTurns.MoveNext())
            {
                playerTurns.Reset();
                playerTurns.MoveNext();
            }
        }
    }
}