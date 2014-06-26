using System;

namespace CodeInvaders.Catan
{
    public class Player
    {
        public Player(string name)
        {
            Name = name;
        }

        public void UpsTheScore(int score)
        {
            Score += score;

            OnScoreIncrease(new ScoreIncreaseEvent(Score, this));
        }

        protected virtual void OnScoreIncrease(ScoreIncreaseEvent scoreIncreaseEvent)
        {
            if (ScoreIncrease != null)
            {
                ScoreIncrease.Invoke(this, scoreIncreaseEvent);
            }
        }

        public EventHandler<ScoreIncreaseEvent> ScoreIncrease;

        public int Score { get; private set; }

        public string Name { get; private set; }
    }

    public class ScoreIncreaseEvent : EventArgs
    {
        public ScoreIncreaseEvent(int score, Player player)
        {
            Player = player;
            Score = score;
        }

        public int Score { get; private set; }
        public Player Player { get; private set; }
    }
}