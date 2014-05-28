namespace CodeInvaders.Catan.App
{
    public class PlayerViewModel
    {
        private readonly Player player;

        public int Score { get; set; }

        public string Name
        {
            get { return player.Name; }
        }

        public bool IsActive { get { return player.IsActive; } }

        public PlayerViewModel(Player player)
        {
            this.player = player;
        }
    }
}