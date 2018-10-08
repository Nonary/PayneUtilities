using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace PayneUtilities
{
    public class RegexMatcher : IMatchParser
    {
        private IMatchParser _parser;

        public RegexMatcher(IMatchParser parser)
        {
            _parser = parser;
        }

        public double GetMatchPercentage(string source, string target)
        {
            return _parser?.GetMatchPercentage(source, target) ?? 0;
            if (source.Length > 6 && target.Length > 6)
            {
                int sourceSplit = target.Length;
                do
                {
                    sourceSplit /= 2;
                } while (sourceSplit > target.Length);

                var likelyMatch = Regex.IsMatch(new string(source.Where(Char.IsLetterOrDigit).ToArray()),
                    $"{new string(target.Where(char.IsLetterOrDigit).ToArray()).Substring(0, sourceSplit)}");

                if (likelyMatch)
                {
                    return 50.00;
                }
            }

            var comparison = _parser?.GetMatchPercentage(source, target) ?? 0;
            //return result > comparison ? result : comparison;
            return 0;

            //todo actually write programming logic for this method.
        }
    }
}