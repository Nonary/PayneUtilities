namespace PayneUtilities
{
    public interface IMatchFactory
    {
        IMatch CreateMatch(string source, string target, double matchConfidence);
    }
}