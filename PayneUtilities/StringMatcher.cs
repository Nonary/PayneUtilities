using System;
using System.Collections.Generic;
using System.Linq;

namespace PayneUtilities
{
    public class StringMatcher
    {
        private readonly IMatchParser _matchParser;
        private readonly IMatchSorter _sorter;

        public StringMatcher() : this(DefaultMatcher(), new DefaultMatchSorter())
        {
        }

        public StringMatcher(IMatchSorter sorter) : this(DefaultMatcher(), sorter)
        {
        }

        public StringMatcher(IMatchParser matchParser, IMatchSorter sorter)
        {
            _matchParser = matchParser;
            _sorter = sorter;
        }


        private static IMatchParser DefaultMatcher()
        {
            return new LevenshteinDistance(new StringContainMatch(null));
        }


        public IEnumerable<IMatch> GetMatches<T1, T2>(IEnumerable<T1> sourceCollection,
            IEnumerable<T2> targetCollection, Func<T1, string> sourceSelector, Func<T2, string> targetSelector,
            IEqualityComparer<T1> distinctComparer = null)
        {
            var matches = new List<Match>();
            var collection = targetCollection as T2[] ?? targetCollection.ToArray();
            foreach (var source in sourceCollection.Distinct(distinctComparer))
            foreach (var target in collection)
            {
                var sourceString = sourceSelector(source);
                var targetString = targetSelector(target);
                var percentage = _matchParser.GetMatchPercentage(sourceString?.ToUpper(), targetString?.ToUpper());
                matches.Add(new Match(sourceString, targetString, percentage));
            }

            return matches;
        }

        public IEnumerable<IMatch> GetAndSortMatches<T1, T2>(IEnumerable<T1> sourceCollection,
            IEnumerable<T2> targetCollection, Func<T1, string> sourceSelector, Func<T2, string> targetSelector,
            IEqualityComparer<T1> distinctComparer = null)
        {
            var matches = GetMatches(sourceCollection, targetCollection, sourceSelector, targetSelector,
                distinctComparer);
            return _sorter.SortMatches(matches);
        }
    }

    public class ConsoleVerifier : IMatchVerifier
    {
        public bool VerifyMatch(IMatch match)
        {
            Console.WriteLine($"{match.SourceString} seems to match with {match.TargetString} with a rating of {match.MatchConfidence}. Confirm Match? Y or N");
            var result = Console.ReadKey().Key == ConsoleKey.Y;
            if (result)
            {
                OnVerified?.Invoke(this, match);
            }

            return result;

        }
    }
}