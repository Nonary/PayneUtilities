namespace PayneUtilities
{
    public interface IMatch
    {
        string SourceString { get; }
        string TargetString { get; }
        double MatchConfidence { get; }
    }

    public class MatchInfo : IMatch
    {
        private IMatch _match;

        public MatchInfo(IMatch match)
        {
            _match = match;
        }

        public string MatchSource { get; set; }
        public string SourceString => _match.SourceString;

        public string TargetString => _match.TargetString;

        public double MatchConfidence => _match.MatchConfidence;
    }
}