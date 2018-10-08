namespace PayneUtilities
{
    public class Match : IMatch
    {
        public Match(string sourceString, string targetString, double matchConfidence)
        {
            SourceString = sourceString;
            TargetString = targetString;
            MatchConfidence = matchConfidence;
        }

        public string SourceString { get; }
        public string TargetString { get; }
        public double MatchConfidence { get; }
    }
}