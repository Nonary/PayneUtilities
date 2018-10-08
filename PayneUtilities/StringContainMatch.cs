using System;
using System.Linq;

namespace PayneUtilities
{
    public class StringContainMatch : IMatchParser
    {
        private readonly IMatchParser _parser;

        public StringContainMatch(IMatchParser parser)
        {
            _parser = parser;
        }

        public double GetMatchPercentage(string source, string target)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(target)) return 0;


            double matchingCharacters = 0;
            var sourceStrings = source.Split(' ');
            var targetStrings = target.Split(' ');

            var sourceIsLarger = source.Length >= target.Length;

            matchingCharacters =
                CalculateMatchingCharacters(matchingCharacters, sourceStrings, targetStrings, sourceIsLarger);

            var sourceWhiteSpaceCount = source.Count(char.IsWhiteSpace);
            var targetWhiteSpaceCount = target.Count(char.IsWhiteSpace);
            matchingCharacters += sourceIsLarger ? sourceWhiteSpaceCount : targetWhiteSpaceCount;

            var amount = matchingCharacters / (sourceIsLarger ? source.Length : target.Length) * 100;
            var wrappedAmount = _parser?.GetMatchPercentage(source, target) ?? 0;
            return amount > wrappedAmount ? amount : wrappedAmount;
        }

        private static double CalculateMatchingCharacters(double matchingCharacters, string[] sourceStrings,
            string[] targetStrings, bool sourceIsLarger)
        {
            foreach (var str in sourceIsLarger ? sourceStrings : targetStrings)
                if (sourceIsLarger && targetStrings.Contains(str))
                    matchingCharacters += str.Length;
                else if (!sourceIsLarger && sourceStrings.Contains(str)) matchingCharacters += str.Length;

            return matchingCharacters;
        }
    }
}