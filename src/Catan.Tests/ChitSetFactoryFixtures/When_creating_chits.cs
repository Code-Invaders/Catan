using NUnit.Framework;
using FluentAssertions;

namespace CodeInvaders.Catan.Tests.ChitSetFactoryFixtures
{
    [TestFixture]
    internal class When_creating_chits
    {
        [Test]
        public void should_give_set_of_random_nums()
        {
            var chitSet = new ChitSetFactory();

            var result = chitSet.CreateChits(12);

            result.Should().HaveCount(12);
        }
    }

}
