namespace PayneUtilities
{
    public class LevenshteinDistanceIgnoreCase : ILevenshteinDistance
    {
        private readonly ILevenshteinDistance _distance;

        public LevenshteinDistanceIgnoreCase(ILevenshteinDistance distance)
        {
            _distance = distance;
        }

        public int GetDistance(string source, string target)
        {
            return _distance.GetDistance(source?.ToUpper(), target?.ToUpper());
        }
    }
}