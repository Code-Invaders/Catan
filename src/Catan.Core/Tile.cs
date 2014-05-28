namespace CodeInvaders.Catan
{
    public class Tile
    {
        public Tile(Resource resource, Chit chit)
        {
            Resource = resource;
            Chit = chit;
        }

        public Resource Resource { get; private set; }
        public Chit Chit { get; private set; }
    }
}