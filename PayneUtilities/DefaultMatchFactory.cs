namespace PayneUtilities
{
    internal class DefaultMatchFactory : IMatchFactory
    {
        public IMatch CreateMatch(string sourceString, string targetString, double distance)
        {
            return new Match(sourceString,targetString, distance);
        }
    }
}