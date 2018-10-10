namespace PayneUtilities
{
    public interface IMatch
    {
        string SourceString { get; }
        string TargetString { get; }
        double MatchConfidence { get; }
    }
}