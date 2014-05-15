using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Catan.App;
using CodeInvaders.Catan.App;
using FluentAssertions;
using NUnit.Framework;

namespace CodeInvaders.Catan.Tests
{
    [TestFixture]
    internal class When_converting_Resources_To_colors
    {
        [TestCaseSource("ResourcesToColors")]
        public void should_chenge_To_the_proper_color(Resource resource, Color expectedColor)
        {
            var actualColor = (SolidColorBrush)new ResourceToColorConverter().Convert(resource, null, null, null);

            actualColor.Color.Should().Be(expectedColor);
        }

        private IEnumerable<ITestCaseData> ResourcesToColors()
        {
            yield return new TestCaseData(Resource.Wood, Colors.DarkGreen).SetName(Resource.Wood.ToString());
            yield return new TestCaseData(Resource.Brick, Colors.Orange).SetName(Resource.Brick.ToString());
            yield return new TestCaseData(Resource.Grain, Colors.Yellow).SetName(Resource.Grain.ToString());
            yield return new TestCaseData(Resource.Ore, Colors.Gray).SetName(Resource.Ore.ToString());
            yield return new TestCaseData(Resource.Sheep, Colors.LightGreen).SetName(Resource.Sheep.ToString());
        }
    }
}
