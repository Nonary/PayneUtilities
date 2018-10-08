using System;

namespace PayneUtilities
{
    public class LevenshteinDistance : IMatchParser
    {
        private readonly IMatchParser _parser;

        public LevenshteinDistance(IMatchParser parser)
        {
            _parser = parser;
        }

        public double GetMatchPercentage(string source, string target)
        {
            var distance = GetDistance(source, target);

            return distance;
        }

        //https://en.wikibooks.org/wiki/Algorithm_Implementation/Strings/Levenshtein_distance#C#
        public int GetDistance(string source, string target)
        {
            if (string.IsNullOrEmpty(source))
            {
                if (string.IsNullOrEmpty(target)) return 0;
                return target.Length;
            }

            if (string.IsNullOrEmpty(target)) return source.Length;

            if (source.Length > target.Length)
            {
                var temp = target;
                target = source;
                source = temp;
            }

            var m = target.Length;
            var n = source.Length;
            var distance = new int[2, m + 1];
            // Initialize the distance matrix
            for (var j = 1; j <= m; j++) distance[0, j] = j;

            var currentRow = 0;
            for (var i = 1; i <= n; ++i)
            {
                currentRow = i & 1;
                distance[currentRow, 0] = i;
                var previousRow = currentRow ^ 1;
                for (var j = 1; j <= m; j++)
                {
                    var cost = target[j - 1] == source[i - 1] ? 0 : 1;
                    distance[currentRow, j] = Math.Min(Math.Min(
                            distance[previousRow, j] + 1,
                            distance[currentRow, j - 1] + 1),
                        distance[previousRow, j - 1] + cost);
                }
            }

            var distancing = distance[currentRow, m];
            if (distancing >= 20) return 0;
            var parsing = _parser?.GetMatchPercentage(source, target) ?? 0;
            return distancing >= parsing ? distancing : Convert.ToInt32(parsing);
        }

        public double GetMatchPercentage(string source, string target)
        {
            int distance = GetDistance(source, target);
            if (distance <= 10)
            {
                return 100-(distance * 10);
            }
            else
            {
                return 0;
            }
        }
    }
}