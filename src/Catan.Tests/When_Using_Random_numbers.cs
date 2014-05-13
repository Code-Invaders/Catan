using CodeInvaders.Catan.App;
using NUnit.Framework;
using FluentAssertions;

namespace CodeInvaders.Catan.Tests
{
    [TestFixture]
    internal class When_Using_Random_numbers
    {
        [Test]
        public void should_give_set_of_random_nums()
        {
            var chitSet = new ChitFactory(13);

            var result = chitSet.StandardOrderedNumberSet;

            result.Should().HaveCount(12);
        }
    }

}
