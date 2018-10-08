using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Moq;
using NUnit.Framework;
using PayneUtilities;
namespace UtilityTests
{
    public class Person

    {
        public Person(string name, string manager)
        {
            Name = name;
            Manager = manager;
        }

        public string Name { get; set; }
        public string Manager { get; set; }


        public string MatchField { get; set; }
    }


    [TestFixture]
    public class LevenshteinTests
    {
        public List<Person> PersonList1 { get; set; }
        public List<Person> PersonList2 { get; set; }

        public LevenshteinTests()
        {
            PersonList1 = new List<Person>()
            {
                new Person("Samantha", "Debbie"),
                new Person("Debbie", "N/A"),
                new Person("Angela", string.Empty),
                new Person("MICHAEL", "John")
            };

            PersonList2 = new List<Person>()
            {
                new Person("Alexander", "Alexis"),
                new Person("Michael", "Debbie"),
                new Person("Charity", "Michael"),
                new Person("Debbie", string.Empty)
            };
        }


        [Test]
        public void OnSortedMatches_FirstResult_ShouldBeLowestDistance()
        {
        
            Assert.Fail();
            
        }


        [Test]
        public void OnSortedMatches_WhenDifferingCase_ShouldBeIgnored()
        {
            Assert.Fail();

        }

    
    }

}