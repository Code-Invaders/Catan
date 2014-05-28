namespace CodeInvaders.Catan.App
{
    public class TileViewModel
    {
        private readonly Tile tile;

        public TileViewModel(Tile tile)
        {
            this.tile = tile;
        }

        public Resource Resource { get { return tile.Resource; } }

        public Chit Chit { get { return tile.Chit; } }
    }
}