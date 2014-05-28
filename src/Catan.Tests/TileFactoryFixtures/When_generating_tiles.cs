using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace CodeInvaders.Catan.Tests.TileSetFactoryFixtures
{
    [TestFixture]
    class When_generating_tiles
    {
        private IEnumerable<Tile> result;

        [SetUp]
        public void SetUp()
        {
            var chitSetFactory = Substitute.For<IChitSetFactory>();
            chitSetFactory.CreateChits(Arg.Any<int>()).Returns(Enumerable.Range(1, 9).Select(x => new Chit(x)));
            var tileFactory = new TileSetFactory(chitSetFactory);

            result = tileFactory.CreateTiles(9);
        }

        [Test]
        public void should_get_9_new_tiles()
        {
            result.Should().HaveCount(9);
        }

        [Test]
        public void should_not_all_be_the_same_type()
        {
            result.GroupBy(x => x.Resource).Count().Should().BeGreaterThan(1);
        }
    }
}
