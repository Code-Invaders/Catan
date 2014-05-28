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
            this.Score += score;
        }

        public int Score { get; private set; }

        public string Name { get; private set; }
    }
}