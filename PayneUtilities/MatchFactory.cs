namespace PayneUtilities
{
    public class MatchFactory : IMatchFactory
    {
        public IMatch CreateMatch(string source, string target, double matchConfidence)
        {
            return  new Match(source,target,matchConfidence);
        }
    }
}