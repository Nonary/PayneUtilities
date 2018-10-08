using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using PayneUtilities;

namespace UtilityTests
{
    [TestFixture]
    public class MatchSorterTests
    {
        private readonly DefaultMatchSorter _sorter;


        public MatchSorterTests()
        {
            _sorter = new DefaultMatchSorter();
        }

        [Test]
        public void OnSorting_WithMultipleResults_ResultsIsOrderedByMatchConfidence()
        {
            var matches = new List<IMatch>
            {
                new Match("Cliff", "Clifton", 0.8d),
                new Match("Chase", "Chase", 1d)
            };

            var results = _sorter.SortMatches(matches);
            Assert.That(results.FirstOrDefault().SourceString, Is.EqualTo("Chase"));
            Assert.That(results.FirstOrDefault().MatchConfidence, Is.EqualTo(1d));
        }


        [Test]
        public void OnSorting_WithSameMatchConfidence_TargetIsOrderedByCase()
        {
            const string alexCorrect = "AlexCorrect";
            const string amandaCorrect = "AmandaCorrect";
            var mocker = new List<IMatch>
            {
                new Match("Alex", "Amanda", .20d),
                new Match(alexCorrect, amandaCorrect, 1d),
                new Match(alexCorrect, "AmandaWrong", 1d),
                new Match("Alex", "AmandaTried", .20d)
            };

            IEnumerable<IMatch> results = null;
            results = new DefaultMatchSorter().SortMatches(mocker);
            Assert.That(results.FirstOrDefault().SourceString, Is.EqualTo(alexCorrect));
            Assert.That(results.FirstOrDefault().TargetString, Is.EqualTo(amandaCorrect));
        }
    }
}