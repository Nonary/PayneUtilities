using System;

namespace PayneUtilities
{
    public class ConsoleVerifier : IMatchVerifier
    {
        public bool VerifyMatch(IMatch match)
        {
            if (match.MatchConfidence >= 99) return false;
            Console.WriteLine();
            Console.WriteLine($"{match.SourceString} seems to match with {match.TargetString}, this is a confidence rating of {match.MatchConfidence:0.00} is this valid? Y/N");
            return Console.ReadKey().Key == ConsoleKey.Y;
        }
    }
}