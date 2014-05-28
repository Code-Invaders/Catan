using System;

namespace CodeInvaders.Catan.App
{
    public class PlayerViewModel
    {
        private readonly Player player;
        private readonly Func<Player, bool> isActive;

        public int Score { get; set; }

        public string Name
        {
            get { return player.Name; }
        }

        public bool IsActive { get { return isActive(player); } }

        public PlayerViewModel(Player player, Func<Player, bool> isActive)
        {
            this.player = player;
            this.isActive = isActive;
        }
    }
}