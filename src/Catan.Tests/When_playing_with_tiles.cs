using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeInvaders.Catan.App;
using FluentAssertions;
using NUnit.Framework;

namespace Catan.Tests
{
    [TestFixture]
    class When_playing_with_tiles
    {
        [Test]
        public void should_get_9_new_tiles()
        {
            var tileFactory = new TileFactory(Enumerable.Range(1, 9).Select(x => new Chit(x)));

            var result = tileFactory.GetTiles(9);

            Assert.AreEqual(9, result.Count());
        }
        [Test]
        public void should_not_all_be_the_same_type()
        {
            var tileFactory = new TileFactory(Enumerable.Range(1, 9).Select(x => new Chit(x)));

            var result = tileFactory.GetTiles(9);

            result.GroupBy(x => x.Resource).Count().Should().BeGreaterThan(1);
        }
    }
}
