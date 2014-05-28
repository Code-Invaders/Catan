using System;
using System.Collections.Generic;

namespace CodeInvaders.Catan
{
    public class ChitSetFactory : IChitSetFactory
    {
        private readonly Random random;

        public ChitSetFactory()
        {
            random = new Random();
        }

        public IEnumerable<Chit> CreateChits(int tileCount)
        {
            for (int i = 0; i < tileCount; i++)
            {
                yield return new Chit(random.Next(2, 12));
            }
        }
    }
}