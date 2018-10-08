using NUnit.Framework;
using PayneUtilities;

namespace UtilityTests
{
    [TestFixture]
    public class StringContainTests
    {
        private readonly StringContainMatch _matcher;

        public StringContainTests()
        {
            _matcher = new StringContainMatch(null);
        }


        [Test]
        public void OnMatchingString_IfBothStringAreSame_MatchShouldBe100Percent()
        {
            var result = _matcher.GetMatchPercentage("HP ELITEBOOK 2570P", "HP ELITEBOOK 2570P");
            Assert.That(result, Is.GreaterThan(.99d));
        }

        [Test]
        public void OnMatchingString_WhenSourceStringIsSmaller_ShouldGiveAccurateMatch()
        {
            var googleChromeEnterprise = "Google Chrome Enterprise";
            var chrome = "Chrome";
            var result = _matcher.GetMatchPercentage(chrome, googleChromeEnterprise);
            Assert.That(result, Is.InRange(33, 34));
        }

        [Test]
        public void OnMatchingString_WhenTargetStringIsSmaller_ShouldGiveAccurateMatch()
        {
            var googleChromeEnterprise = "Google Chrome Enterprise";
            var chrome = "Chrome";
            var result = _matcher.GetMatchPercentage(googleChromeEnterprise, chrome);
            Assert.That(result, Is.InRange(33,34));
        }
    }
}