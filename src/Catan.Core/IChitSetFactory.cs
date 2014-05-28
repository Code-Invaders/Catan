using System.Collections.Generic;

namespace CodeInvaders.Catan
{
    public interface IChitSetFactory
    {
        IEnumerable<Chit> CreateChits(int tileCount);
    }
}