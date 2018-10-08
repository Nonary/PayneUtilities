using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using PayneUtilities;

namespace UtilityTests
{
    [TestFixture]
    public class StringMatcherTests
    {
        private readonly StringMatcher _matcher;


        public StringMatcherTests()
        {
            _matcher = new StringMatcher();
        }

        [Test]
        public void OnMatching_WhenCaseDiffers_ShouldBePerfectMatch()
        {
            var firstList = new List<string>
            {
                "Person 1",
                "Person 2"
            };

            var secondList = new List<string>
            {
                "PERSON 1",
                "PERSON 2"
            };

            var matches = _matcher.GetMatches(firstList, secondList, x => x, x => x);

            Assert.That(matches.FirstOrDefault().MatchConfidence, Is.EqualTo(100d));
        }


        [Test]
        public void OnMatching_WithDuplicateSource_ResultsShouldBeDistinct()
        {
            var list1 = new List<Person>
            {
                new Person {Name = "Amanda"},
                new Person {Name = "Amanda"},
                new Person {Name = "Amanda"}
            };

            var list2 = new[]
            {
                new Person {Name = "Amanda1"},
                new Person {Name = "Amanda2"},
                new Person {Name = "Amanda3"}
            };

            var matches = _matcher.GetMatches(list1, list2, arg => arg.Name, arg => arg.Name, list1[0]);
            Assert.That(matches.Count(), Is.EqualTo(3));
        }
        [Test]
        public void OnMatching_WithVastlyDifferentString_ShouldReturn0()
        {
            var items = new[]
            {
                new {Name = "weinfweionogiwengewopovgnewoignwergnruwwquoeqhnfuibufboewnipfwenghur"}
            };

            var items2 = new[]
            {
                new {Name = "Amaazon"}
            };

            var result = _matcher.GetMatches(items, items2, arg => arg.Name, arg => arg.Name);

            Assert.That(result.FirstOrDefault().MatchConfidence, Is.Zero);
        }
    }

    public class Person : IEqualityComparer<Person>
    {
        public string Name { get; set; }

        public bool Equals(Person x, Person y)
        {
            return x.Name == y.Name;
        }

        public int GetHashCode(Person obj)
        {
            return obj.Name.GetHashCode();
        }

        public bool Equals(Person other)
        {
            return Name == other.Name;
        }
    }
}