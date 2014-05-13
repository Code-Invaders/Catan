using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeInvaders.Catan.App
{
    public class ChitFactory
    {
        
        public IEnumerable<Chit> StandardOrderedNumberSet;

        private Random _Random;

        public ChitFactory(int extent)
        {
            StandardOrderedNumberSet = StandardOrderedNumberSetCreator(extent);

            _Random = new Random();
        }

        private IEnumerable<Chit> StandardOrderedNumberSetCreator(int extent)
        {
            for (int i = 2; i <= extent; i++)
            {
                yield return new Chit(_Random.Next(2, 12));
            }
        }
    }

    

    public class Chit
    {
        public int IdentifyingNumber { get; private set; }

        public Chit(int identifyingNumber)
        {
            IdentifyingNumber = identifyingNumber;
        }

    }
}
